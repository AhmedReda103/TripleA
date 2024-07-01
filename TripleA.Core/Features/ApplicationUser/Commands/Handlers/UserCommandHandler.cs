using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TripleA.Core.Bases;
using TripleA.Core.Features.ApplicationUser.Commands.Models;
using TripleA.Core.Resources;
using TripleA.Data.Entities.Identity;
using TripleA.Domain.Results;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
        , IRequestHandler<SignInCommand, Response<JwtAuthResult>>
        , IRequestHandler<LogoutCommand, Response<string>>
        , IRequestHandler<DeleteUserCommand, Response<string>>
    {

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IApplicationUserService _applicationUserService;
        private readonly SignInManager<User> _signInManager;


        public UserCommandHandler(
                              IMapper mapper,
                              IApplicationUserService applicationUserService,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager
                              )

        {
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            _signInManager = signInManager;
            _userManager = userManager;

        }



        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<User>(request);
            //Create
            var createResult = await _applicationUserService.AddUserAsync(identityUser, request.Password);

            return getResponse(createResult);

        }


        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await _userManager.FindByEmailAsync(request.Email);
            //Return The UserName Not Found
            if (user == null) return BadRequest<JwtAuthResult>(SharedResourcesKeys.EmailIsNotExist);
            //try To Sign in 
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if Failed Return Passord is wrong
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>(SharedResourcesKeys.PasswordNotCorrect);
            //Generate Token
            var result = await _applicationUserService.GetJWTToken(user);
            //return Token 
            return Success(result);
        }


        public Response<string> getResponse(string createResult)
        {
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>(SharedResourcesKeys.EmailIsExist);
                case "UserNameIsExist": return BadRequest<string>(SharedResourcesKeys.UserNameIsExist);
                case "ErrorInCreateUser": return BadRequest<string>(SharedResourcesKeys.FaildToAddUser);
                case "Failed": return BadRequest<string>(SharedResourcesKeys.TryToRegisterAgain);
                case "Success": return Success(SharedResourcesKeys.Success);
                default: return BadRequest<string>(createResult);
            }
        }

        public async Task<Response<string>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Success("Successfully logged out");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserService.GetUserByIdAsync(request.Id);

            if (user == null) return NotFound<string>("user is Not Found");

            var result = await _applicationUserService.DeleteUserAsync(user);
            if (result == "Success") return Deleted<string>($"Delete Successfully {request.Id}");
            else return BadRequest<string>();
        }
    }
}

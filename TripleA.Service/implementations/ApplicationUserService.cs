
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TripleA.Data.Entities.Identity;
using TripleA.Data.Helpers;
using TripleA.Domain.Results;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;


namespace TripleA.Service.implementations
{
    internal class ApplicationUserService : IApplicationUserService
    {

        private readonly JwtSettings _jwtSettings;
        public readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public ApplicationUserService(
            JwtSettings jwtSettings,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor
            )
        {

            _jwtSettings = jwtSettings;
            _httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;

        }

        public async Task<string> AddUserAsync(User user, string password)
        {
            var trans = await unitOfWork._context.Database.BeginTransactionAsync();
            try
            {
                //if Email is Exist
                var existUser = await unitOfWork._userManager.FindByEmailAsync(user.Email);
                //email is Exist
                if (existUser != null) return "EmailIsExist";

                //if username is Exist
                var userByUserName = await unitOfWork._userManager.FindByNameAsync(user.UserName);
                //username is Exist
                if (userByUserName != null) return "UserNameIsExist";
                //Create
                var createResult = await unitOfWork._userManager.CreateAsync(user, password);
                //Failed
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());


                //assign User To Role
                await assignUserRole(user);

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }



        private async Task assignUserRole(User user)
        {
            await unitOfWork._userManager.AddToRoleAsync(user, "USER");

        }


        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var (jwtToken, accessToken) = await GenerateJWTToken(user);

            var response = new JwtAuthResult();
            response.AccessToken = accessToken;

            return response;
        }


        private async Task<(JwtSecurityToken, string)> GenerateJWTToken(User user)
        {
            var claims = await GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }

        public async Task<List<Claim>> GetClaims(User user)
        {
            var roles = await unitOfWork._userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var userClaims = await unitOfWork._userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);
            return claims;
        }

        public async Task<string> getUserIdAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // Retrieve the user's claims from the HttpContext
            var userClaims = httpContext.User.Claims;

            // Find the claim representing the user's ID (typically named "sub")
            var userIdClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                // User ID claim not found
                return null;
            }

            // Extract the user ID from the claim
            var userId = userIdClaim.Value;
            return userId;
        }

        public async Task upUser(string userId)
        {
            var user = await unitOfWork.Users.GetByIdAsync(userId);
            user.Votes++;
            await unitOfWork.SaveChangesAsync();
        }
    }
}

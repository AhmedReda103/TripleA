using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{
    public class RealTimeService : Hub
    {

        IUserConService _userConService;
        IApplicationUserService _appUserService;
        public RealTimeService(IUserConService userCon, IApplicationUserService appUserService)
        {
            _userConService = userCon;
            _appUserService = appUserService;
        }

        [HubMethodName("sendNotification")]
        public async Task SendNotification(string userId, string message)
        {
            await Clients.User(userId).SendAsync("receivenotification", message);

        }

        [HubMethodName("reauthme")]
        public async Task reauthMe(string personId)
        {
            string currSignalrID = this.Context.ConnectionId;

            UserCon tempPerson = _userConService.GetAll().Result.FirstOrDefault(p => p.UserId == personId);

            if (tempPerson == null) //if credentials are correct
            {
                UserCon currUser = new UserCon
                {
                    UserId = personId,
                    UserConnection = currSignalrID,
                    LoginIn = DateTime.Now
                };
                await _userConService.AddUserConAsync(currUser);
                Debug.WriteLine("\n" + currUser.UserId + " logged in" + "\nSignalrID: " + currSignalrID);

            }


            await Clients.User(personId).SendAsync("reauthMeResponse", tempPerson);//4Tutorial
            await Clients.Others.SendAsync("userOn", tempPerson);//4Tutorial
        } //end of reauthMe


        /*        public override async Task OnConnectedAsync()
                {

                    var userId = await _appUserService.getUserIdAsync();
                    // Map userId to connectionId if necessary
                    var userCon = new UserCon()
                    {
                        LoginIn = DateTime.Now,
                        UserId = userId,
                        UserConnection = this.Context.ConnectionId,
                    };
                    await _userConService.AddUserConAsync(userCon);
                    await base.OnConnectedAsync();
                }*/




        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userConnection = _userConService.GetAll().Result.FirstOrDefault(c => c.UserConnection == this.Context.ConnectionId);

            await _userConService.DeleteAsync(userConnection);

            await base.OnDisconnectedAsync(exception);

        }

    }
}

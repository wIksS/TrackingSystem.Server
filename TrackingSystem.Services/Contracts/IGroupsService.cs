using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Models;

namespace TrackingSystem.Services.Contracts
{
    public interface IGroupsService
    {
        Group ChangeDistance(int newDistance, string userId);

        void RemoveFromGroup(Student user);

        Group CreateGroup(ApplicationUser user);
    }
}

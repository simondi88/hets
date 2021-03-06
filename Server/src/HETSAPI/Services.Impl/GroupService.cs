/*
 * REST API Documentation for the MOTI Hired Equipment Tracking System (HETS) Application
 *
 * The Hired Equipment Program is for owners/operators who have a dump truck, bulldozer, backhoe or  other piece of equipment they want to hire out to the transportation ministry for day labour and  emergency projects.  The Hired Equipment Program distributes available work to local equipment owners. The program is  based on seniority and is designed to deliver work to registered users fairly and efficiently  through the development of local area call-out lists. 
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using HETSAPI.Models;
using HETSAPI.ViewModels;
using HETSAPI.Mappings;

namespace HETSAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class GroupService : IGroupService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public GroupService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// returns users in a given Group
        /// </summary>
        /// <remarks>Used to get users in a given Group</remarks>
        /// <param name="id">id of Group to fetch Users for</param>
        /// <response code="200">OK</response>
        public IActionResult GroupsIdUsersGetAsync(int id)
        {
            bool exists = _context.Groups.Any(a => a.Id == id);
            if (exists)
            {
                var result = new List<UserViewModel>();
                var data = _context.GroupMemberships
                    .Include("User")
                    .Include("Group")
                    .Where(x => x.Group.Id == id);

                // extract the users
                foreach (var item in data)
                {
                    result.Add(item.User.ToViewModel());
                }
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Groups created</response>
        public IActionResult GroupsBulkPostAsync(Group[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Group item in items)
            {

                bool exists = _context.Groups.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Groups.Update(item);
                }
                else
                {
                    _context.Groups.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of groups</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult GroupsGetAsync()
        {
            var result = _context.Groups.Select(x => x.ToViewModel()).ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdDeletePostAsync(int id)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Groups.First(a => a.Id == id);
                if (item != null)
                {
                    _context.Groups.Remove(item);
                    // Save the changes
                    _context.SaveChanges();
                }
                return new ObjectResult(item);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a Group</remarks>
        /// <param name="id">id of Group to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdGetAsync(int id)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Groups.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdPutAsync(int id, Group item)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.Groups.Update(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Group created</response>
        public IActionResult GroupsPostAsync(Group item)
        {
            var exists = _context.Groups.Any(a => a.Id == item.Id);
            if (exists)
            {
                _context.Groups.Update(item);
            }
            else
            {
                // record not found
                _context.Groups.Add(item);
            }

            _context.SaveChanges();
            return new ObjectResult(item);
        }


    }
}

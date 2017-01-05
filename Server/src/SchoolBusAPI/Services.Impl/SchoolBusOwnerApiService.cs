/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
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
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class SchoolBusOwnerApiService : ISchoolBusOwnerApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns list of available FavouriteContextTypes</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult FavouritecontexttypesGetAsync()
        {
            var result = _context.FavouriteContextTypes.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwners created</response>
        public virtual IActionResult SchoolbusownersBulkPostAsync(SchoolBusOwner[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwner item in items)
            {
                _context.SchoolBusOwners.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownersGetAsync()
        {
            var result = _context.SchoolBusOwners.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownersIdAttachmentsGetAsync(int id)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerAttachments.Where(a => a.SchoolBusOwner.Id == id);
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
        /// <remarks>Returns address contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact address for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownersIdContactaddressesGetAsync(int id)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerContactAddresss.Where(a => a.SchoolBusOwnerContact.SchoolBusOwner.Id == id);
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
        /// <remarks>Returns phone contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact phone for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownersIdContactphonesGetAsync(int id)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerContactPhones.Where(a => a.SchoolBusOwnerContact.SchoolBusOwner.Id == id);
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
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        public virtual IActionResult SchoolbusownersIdDeleteAsync(int id)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusOwners.First(a => a.Id == id);            
                _context.SchoolBusOwners.Remove(item);
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
        /// <remarks>Returns a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownersIdGetAsync(int id)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwners.First(a => a.Id == id);
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
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownersIdNotesGetAsync(int id)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerNotes.Where(a => a.SchoolBusOwner.Id == id);
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
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        public virtual IActionResult SchoolbusownersIdPutAsync(int id, SchoolBusOwner item)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var dbItem = _context.SchoolBusOwners.First(a => a.Id == id);
                dbItem.ServiceArea = item.ServiceArea;
                dbItem.DateCreated = item.DateCreated;
                dbItem.Status = item.Status;
                dbItem.ServiceArea = item.ServiceArea;
                dbItem.Name = item.Name;
                dbItem.PrimaryContact = item.PrimaryContact;
                
                _context.SchoolBusOwners.Update(dbItem);
                // Save the changes
                _context.SaveChanges();                
                return new ObjectResult(dbItem);
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
        /// <response code="201">SchoolBusOwner created</response>
        public virtual IActionResult SchoolbusownersPostAsync(SchoolBusOwner item)
        {
            _context.SchoolBusOwners.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}

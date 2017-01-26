/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// Attachments uploaded by users about instance of entities - e.g. School Buses and School Bus Owners
    /// </summary>
        [MetaDataExtension (Description = "Attachments uploaded by users about instance of entities - e.g. School Buses and School Bus Owners")]

    public partial class Attachment : IEquatable<Attachment>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public Attachment()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attachment" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="InternalFileName">The physical location of the attachment on the file system..</param>
        /// <param name="ExternalFileName">The name of the attachment as defined by the user in uploading the document..</param>
        /// <param name="Description">A note about the attachment,  optionally maintained by the user..</param>
        public Attachment(int Id, string InternalFileName = null, string ExternalFileName = null, string Description = null)
        {   
            this.Id = Id;
            this.InternalFileName = InternalFileName;
            this.ExternalFileName = ExternalFileName;
            this.Description = Description;
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }
        
        /// <summary>
        /// The physical location of the attachment on the file system.
        /// </summary>
        /// <value>The physical location of the attachment on the file system.</value>
        [MetaDataExtension (Description = "The physical location of the attachment on the file system.")]
        public string InternalFileName { get; set; }
        
        /// <summary>
        /// The name of the attachment as defined by the user in uploading the document.
        /// </summary>
        /// <value>The name of the attachment as defined by the user in uploading the document.</value>
        [MetaDataExtension (Description = "The name of the attachment as defined by the user in uploading the document.")]
        public string ExternalFileName { get; set; }
        
        /// <summary>
        /// A note about the attachment,  optionally maintained by the user.
        /// </summary>
        /// <value>A note about the attachment,  optionally maintained by the user.</value>
        [MetaDataExtension (Description = "A note about the attachment,  optionally maintained by the user.")]
        public string Description { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Attachment {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InternalFileName: ").Append(InternalFileName).Append("\n");
            sb.Append("  ExternalFileName: ").Append(ExternalFileName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            if (ReferenceEquals(this, obj)) { return true; }
            if (obj.GetType() != GetType()) { return false; }
            return Equals((Attachment)obj);
        }

        /// <summary>
        /// Returns true if Attachment instances are equal
        /// </summary>
        /// <param name="other">Instance of Attachment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Attachment other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.InternalFileName == other.InternalFileName ||
                    this.InternalFileName != null &&
                    this.InternalFileName.Equals(other.InternalFileName)
                ) &&                 
                (
                    this.ExternalFileName == other.ExternalFileName ||
                    this.ExternalFileName != null &&
                    this.ExternalFileName.Equals(other.ExternalFileName)
                ) &&                 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.InternalFileName != null)
                {
                    hash = hash * 59 + this.InternalFileName.GetHashCode();
                }                
                                if (this.ExternalFileName != null)
                {
                    hash = hash * 59 + this.ExternalFileName.GetHashCode();
                }                
                                if (this.Description != null)
                {
                    hash = hash * 59 + this.Description.GetHashCode();
                }                
                
                return hash;
            }
        }

        #region Operators
        
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Attachment left, Attachment right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Attachment left, Attachment right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
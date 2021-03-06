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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HETSAPI.Models;

namespace HETSAPI.Models
{
    /// <summary>
    /// Information about the hiring of a specific piece of equipment to satisfy part or all of a request from a project. TABLE DEFINITION IN PROGRESS - MORE COLUMNS TO BE ADDED
    /// </summary>
        [MetaDataExtension (Description = "Information about the hiring of a specific piece of equipment to satisfy part or all of a request from a project. TABLE DEFINITION IN PROGRESS - MORE COLUMNS TO BE ADDED")]

    public partial class RentalAgreement : AuditableEntity, IEquatable<RentalAgreement>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public RentalAgreement()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalAgreement" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a RentalAgreement (required).</param>
        /// <param name="Number">A system-generated unique rental agreement number in a format defined by the business as suitable for the business and client to see and use. (required).</param>
        /// <param name="Status">The current status of the Rental Agreement, such as Active or Complete (required).</param>
        /// <param name="Equipment">A foreign key reference to the system-generated unique identifier for an Equipment (required).</param>
        /// <param name="Project">A foreign key reference to the system-generated unique identifier for a Project (required).</param>
        /// <param name="RentalAgreementRates">RentalAgreementRates.</param>
        /// <param name="RentalAgreementConditions">RentalAgreementConditions.</param>
        /// <param name="TimeRecords">TimeRecords.</param>
        /// <param name="Note">An optional note to be placed onto the Rental Agreement..</param>
        /// <param name="EstimateStartWork">The estimated start date of the work to be placed on the rental agreement..</param>
        /// <param name="DatedOn">The dated on date to put on the Rental Agreement..</param>
        /// <param name="EstimateHours">The estimated number of hours of work to be put onto the Rental Agreement..</param>
        /// <param name="EquipmentRate">The dollar rate for the piece of equipment itself for this Rental Agreement. Other rates associated with the Rental Agreement are in the Rental Agreement Rate table..</param>
        /// <param name="RatePeriod">The period of the rental rate. The vast majority will be hourly, but the rate could apply across a different period, e.g. daily..</param>
        /// <param name="RateComment">A comment about the rate for the piece of equipment..</param>
        public RentalAgreement(int Id, string Number, string Status, Equipment Equipment, Project Project, List<RentalAgreementRate> RentalAgreementRates = null, List<RentalAgreementCondition> RentalAgreementConditions = null, List<TimeRecord> TimeRecords = null, string Note = null, DateTime? EstimateStartWork = null, DateTime? DatedOn = null, int? EstimateHours = null, float? EquipmentRate = null, string RatePeriod = null, string RateComment = null)
        {   
            this.Id = Id;
            this.Number = Number;
            this.Status = Status;
            this.Equipment = Equipment;
            this.Project = Project;




            this.RentalAgreementRates = RentalAgreementRates;
            this.RentalAgreementConditions = RentalAgreementConditions;
            this.TimeRecords = TimeRecords;
            this.Note = Note;
            this.EstimateStartWork = EstimateStartWork;
            this.DatedOn = DatedOn;
            this.EstimateHours = EstimateHours;
            this.EquipmentRate = EquipmentRate;
            this.RatePeriod = RatePeriod;
            this.RateComment = RateComment;
        }

        /// <summary>
        /// A system-generated unique identifier for a RentalAgreement
        /// </summary>
        /// <value>A system-generated unique identifier for a RentalAgreement</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a RentalAgreement")]
        public int Id { get; set; }
        
        /// <summary>
        /// A system-generated unique rental agreement number in a format defined by the business as suitable for the business and client to see and use.
        /// </summary>
        /// <value>A system-generated unique rental agreement number in a format defined by the business as suitable for the business and client to see and use.</value>
        [MetaDataExtension (Description = "A system-generated unique rental agreement number in a format defined by the business as suitable for the business and client to see and use.")]
        [MaxLength(30)]
        
        public string Number { get; set; }
        
        /// <summary>
        /// The current status of the Rental Agreement, such as Active or Complete
        /// </summary>
        /// <value>The current status of the Rental Agreement, such as Active or Complete</value>
        [MetaDataExtension (Description = "The current status of the Rental Agreement, such as Active or Complete")]
        [MaxLength(50)]
        
        public string Status { get; set; }
        
        /// <summary>
        /// A foreign key reference to the system-generated unique identifier for an Equipment
        /// </summary>
        /// <value>A foreign key reference to the system-generated unique identifier for an Equipment</value>
        [MetaDataExtension (Description = "A foreign key reference to the system-generated unique identifier for an Equipment")]
        public Equipment Equipment { get; set; }
        
        /// <summary>
        /// Foreign key for Equipment 
        /// </summary>   
        [ForeignKey("Equipment")]
		[JsonIgnore]
		[MetaDataExtension (Description = "A foreign key reference to the system-generated unique identifier for an Equipment")]
        public int? EquipmentId { get; set; }
        
        /// <summary>
        /// A foreign key reference to the system-generated unique identifier for a Project
        /// </summary>
        /// <value>A foreign key reference to the system-generated unique identifier for a Project</value>
        [MetaDataExtension (Description = "A foreign key reference to the system-generated unique identifier for a Project")]
        public Project Project { get; set; }
        
        /// <summary>
        /// Foreign key for Project 
        /// </summary>   
        [ForeignKey("Project")]
		[JsonIgnore]
		[MetaDataExtension (Description = "A foreign key reference to the system-generated unique identifier for a Project")]
        public int? ProjectId { get; set; }
        
        /// <summary>
        /// Gets or Sets RentalAgreementRates
        /// </summary>
        public List<RentalAgreementRate> RentalAgreementRates { get; set; }
        
        /// <summary>
        /// Gets or Sets RentalAgreementConditions
        /// </summary>
        public List<RentalAgreementCondition> RentalAgreementConditions { get; set; }
        
        /// <summary>
        /// Gets or Sets TimeRecords
        /// </summary>
        public List<TimeRecord> TimeRecords { get; set; }
        
        /// <summary>
        /// An optional note to be placed onto the Rental Agreement.
        /// </summary>
        /// <value>An optional note to be placed onto the Rental Agreement.</value>
        [MetaDataExtension (Description = "An optional note to be placed onto the Rental Agreement.")]
        [MaxLength(2048)]
        
        public string Note { get; set; }
        
        /// <summary>
        /// The estimated start date of the work to be placed on the rental agreement.
        /// </summary>
        /// <value>The estimated start date of the work to be placed on the rental agreement.</value>
        [MetaDataExtension (Description = "The estimated start date of the work to be placed on the rental agreement.")]
        public DateTime? EstimateStartWork { get; set; }
        
        /// <summary>
        /// The dated on date to put on the Rental Agreement.
        /// </summary>
        /// <value>The dated on date to put on the Rental Agreement.</value>
        [MetaDataExtension (Description = "The dated on date to put on the Rental Agreement.")]
        public DateTime? DatedOn { get; set; }
        
        /// <summary>
        /// The estimated number of hours of work to be put onto the Rental Agreement.
        /// </summary>
        /// <value>The estimated number of hours of work to be put onto the Rental Agreement.</value>
        [MetaDataExtension (Description = "The estimated number of hours of work to be put onto the Rental Agreement.")]
        public int? EstimateHours { get; set; }
        
        /// <summary>
        /// The dollar rate for the piece of equipment itself for this Rental Agreement. Other rates associated with the Rental Agreement are in the Rental Agreement Rate table.
        /// </summary>
        /// <value>The dollar rate for the piece of equipment itself for this Rental Agreement. Other rates associated with the Rental Agreement are in the Rental Agreement Rate table.</value>
        [MetaDataExtension (Description = "The dollar rate for the piece of equipment itself for this Rental Agreement. Other rates associated with the Rental Agreement are in the Rental Agreement Rate table.")]
        public float? EquipmentRate { get; set; }
        
        /// <summary>
        /// The period of the rental rate. The vast majority will be hourly, but the rate could apply across a different period, e.g. daily.
        /// </summary>
        /// <value>The period of the rental rate. The vast majority will be hourly, but the rate could apply across a different period, e.g. daily.</value>
        [MetaDataExtension (Description = "The period of the rental rate. The vast majority will be hourly, but the rate could apply across a different period, e.g. daily.")]
        [MaxLength(50)]
        
        public string RatePeriod { get; set; }
        
        /// <summary>
        /// A comment about the rate for the piece of equipment.
        /// </summary>
        /// <value>A comment about the rate for the piece of equipment.</value>
        [MetaDataExtension (Description = "A comment about the rate for the piece of equipment.")]
        [MaxLength(2048)]
        
        public string RateComment { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RentalAgreement {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Equipment: ").Append(Equipment).Append("\n");
            sb.Append("  Project: ").Append(Project).Append("\n");
            sb.Append("  RentalAgreementRates: ").Append(RentalAgreementRates).Append("\n");
            sb.Append("  RentalAgreementConditions: ").Append(RentalAgreementConditions).Append("\n");
            sb.Append("  TimeRecords: ").Append(TimeRecords).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  EstimateStartWork: ").Append(EstimateStartWork).Append("\n");
            sb.Append("  DatedOn: ").Append(DatedOn).Append("\n");
            sb.Append("  EstimateHours: ").Append(EstimateHours).Append("\n");
            sb.Append("  EquipmentRate: ").Append(EquipmentRate).Append("\n");
            sb.Append("  RatePeriod: ").Append(RatePeriod).Append("\n");
            sb.Append("  RateComment: ").Append(RateComment).Append("\n");
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
            return Equals((RentalAgreement)obj);
        }

        /// <summary>
        /// Returns true if RentalAgreement instances are equal
        /// </summary>
        /// <param name="other">Instance of RentalAgreement to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RentalAgreement other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.Number == other.Number ||
                    this.Number != null &&
                    this.Number.Equals(other.Number)
                ) &&                 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) &&                 
                (
                    this.Equipment == other.Equipment ||
                    this.Equipment != null &&
                    this.Equipment.Equals(other.Equipment)
                ) &&                 
                (
                    this.Project == other.Project ||
                    this.Project != null &&
                    this.Project.Equals(other.Project)
                ) && 
                (
                    this.RentalAgreementRates == other.RentalAgreementRates ||
                    this.RentalAgreementRates != null &&
                    this.RentalAgreementRates.SequenceEqual(other.RentalAgreementRates)
                ) && 
                (
                    this.RentalAgreementConditions == other.RentalAgreementConditions ||
                    this.RentalAgreementConditions != null &&
                    this.RentalAgreementConditions.SequenceEqual(other.RentalAgreementConditions)
                ) && 
                (
                    this.TimeRecords == other.TimeRecords ||
                    this.TimeRecords != null &&
                    this.TimeRecords.SequenceEqual(other.TimeRecords)
                ) &&                 
                (
                    this.Note == other.Note ||
                    this.Note != null &&
                    this.Note.Equals(other.Note)
                ) &&                 
                (
                    this.EstimateStartWork == other.EstimateStartWork ||
                    this.EstimateStartWork != null &&
                    this.EstimateStartWork.Equals(other.EstimateStartWork)
                ) &&                 
                (
                    this.DatedOn == other.DatedOn ||
                    this.DatedOn != null &&
                    this.DatedOn.Equals(other.DatedOn)
                ) &&                 
                (
                    this.EstimateHours == other.EstimateHours ||
                    this.EstimateHours != null &&
                    this.EstimateHours.Equals(other.EstimateHours)
                ) &&                 
                (
                    this.EquipmentRate == other.EquipmentRate ||
                    this.EquipmentRate != null &&
                    this.EquipmentRate.Equals(other.EquipmentRate)
                ) &&                 
                (
                    this.RatePeriod == other.RatePeriod ||
                    this.RatePeriod != null &&
                    this.RatePeriod.Equals(other.RatePeriod)
                ) &&                 
                (
                    this.RateComment == other.RateComment ||
                    this.RateComment != null &&
                    this.RateComment.Equals(other.RateComment)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.Number != null)
                {
                    hash = hash * 59 + this.Number.GetHashCode();
                }                
                                if (this.Status != null)
                {
                    hash = hash * 59 + this.Status.GetHashCode();
                }                
                                   
                if (this.Equipment != null)
                {
                    hash = hash * 59 + this.Equipment.GetHashCode();
                }                   
                if (this.Project != null)
                {
                    hash = hash * 59 + this.Project.GetHashCode();
                }                   
                if (this.RentalAgreementRates != null)
                {
                    hash = hash * 59 + this.RentalAgreementRates.GetHashCode();
                }                   
                if (this.RentalAgreementConditions != null)
                {
                    hash = hash * 59 + this.RentalAgreementConditions.GetHashCode();
                }                   
                if (this.TimeRecords != null)
                {
                    hash = hash * 59 + this.TimeRecords.GetHashCode();
                }                if (this.Note != null)
                {
                    hash = hash * 59 + this.Note.GetHashCode();
                }                
                                if (this.EstimateStartWork != null)
                {
                    hash = hash * 59 + this.EstimateStartWork.GetHashCode();
                }                
                                if (this.DatedOn != null)
                {
                    hash = hash * 59 + this.DatedOn.GetHashCode();
                }                
                                if (this.EstimateHours != null)
                {
                    hash = hash * 59 + this.EstimateHours.GetHashCode();
                }                
                                if (this.EquipmentRate != null)
                {
                    hash = hash * 59 + this.EquipmentRate.GetHashCode();
                }                
                                if (this.RatePeriod != null)
                {
                    hash = hash * 59 + this.RatePeriod.GetHashCode();
                }                
                                if (this.RateComment != null)
                {
                    hash = hash * 59 + this.RateComment.GetHashCode();
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
        public static bool operator ==(RentalAgreement left, RentalAgreement right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(RentalAgreement left, RentalAgreement right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}

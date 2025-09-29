using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intranetMVC.Models
{
    /// <summary>
    /// Represents a single attendance record (e.g., a clock-in or a clock-out event).
    /// </summary>
    public class Attendance
    {
        // 1. Primary Key
        [Key]
        [Display(Name = "Attendance ID")]
        public int AsistenciaId { get; set; }

        // 2. Foreign Key: Links this record to the user (Employee or Student)
        [Required]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        // 3. The crucial timestamp for the event
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time of Record")]
        // Standard format for displaying date and time, common in older systems
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime RecordTimestamp { get; set; }

        // 4. Type of Event: Defines if it's an entry, exit, or break
        [Required]
        [StringLength(50)]
        [Display(Name = "Record Type")]
        public string RecordType { get; set; }
        /* Common values: 
         * "ENTRY" (Clock In), 
         * "EXIT" (Clock Out), 
         * "BREAK_START", 
         * "BREAK_END" 
        */

        // 5. Source/Location: Useful for auditing (e.g., Biometric, Web, Mobile)
        [StringLength(100)]
        [Display(Name = "Location/Source")]
        public string LocationSource { get; set; }

        // 6. Status Flag: To mark if the record is approved or needs review (e.g., if late)
        [Display(Name = "Is Valid")]
        public bool IsValid { get; set; } = true; // Defaulting to valid

        // 7. (Optional) For storing IP address or device identifier
        [StringLength(50)]
        public string DeviceIdentifier { get; set; }

        // 8. (Optional) Notes for manual overrides or explanations
        [StringLength(500)]
        public string Notes { get; set; }
    }
}
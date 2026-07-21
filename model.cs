using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyncServer
{
    public interface ISyncTables
    {
        public int DBID { get; set; }
        public DateTime? Modification_Time { get; set; }
        public bool IsDeleted { get; set; }

    };
    [Table("dict")]
    [Index(nameof(Modification_Time))]
    public class Dict : ISyncTables
    {
        public int DBID { get; set; }
        public string Word { get; set; } = string.Empty;
        public string Translation { get; set; } = string.Empty;
        public string? TopicName { get; set; }

        // Храним только дату (без времени)
        [Column(TypeName = "date")]
        public DateOnly DateRec { get; set; }

        [Column("Score")]
        public byte Grade { get; set; }
        public bool Usersel { get; set; }
        public bool Phrase { get; set; }
        public byte Relevation { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Modification_Time { get; set; }
        // Если это поле нужно
        public bool Spot { get; set; }
    }
    

    [Table("topic")]
    [Index(nameof(Modification_Time))]
    public class Topic: ISyncTables
    {
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime? Modification_Time { get; set; }
        public int DBID { get; set; }
    }
}
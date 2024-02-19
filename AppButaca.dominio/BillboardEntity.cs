using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.dominio
{
    public class BillboardEntity : BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime StartTime { get; set; } //TimeSpan

        [Required]
        public DateTime EndTime { get; set; } //TimeSpan

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public RoomEntity Room { get; set; }

    }
}

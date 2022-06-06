using System;
using System.Collections.Generic;

namespace SunOnDemilich.Entities
{
    public partial class TbVgkg
    {
        public int Id { get; set; }
        /// <summary>
        /// Get the image&apos;s publication date and time.
        /// </summary>
        public string Dttme { get; set; } = null!;
        /// <summary>
        /// Gets the source URI of the image.
        /// </summary>
        public string? Srce { get; set; }
        /// <summary>
        /// Gets the source URI of the first article that used the image.
        /// </summary>
        public string? Srcfd { get; set; }
    }
}

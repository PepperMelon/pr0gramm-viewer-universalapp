using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Model
{
    public class Comment
    {
        private int created;

        public int Id;

        public int Parent { get; set; }

        public int? Level { get; set; }

        public string Content { get; set; }

        public int Created { get; set; }

        public DateTime ReadableCreatedTime { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public int Points { get; set; }
        public double Confidence;
        public string Name { get; set; }
        public int Mark { get; set; }
    }
}

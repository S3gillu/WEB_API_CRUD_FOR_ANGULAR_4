using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1.VIEWMODEL
{
    public class ResponseViewModel
    {
        //ALpit.
        public long Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        ///     Sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///     true/false
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Sets the content.
        /// </summary>
        public object Content { get; set; }
    }
}

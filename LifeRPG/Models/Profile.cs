
using System.ComponentModel;

namespace LifeRPG.Models
{
    public partial class Profile
    {
        /// <summary>
        /// name, title, avatar, description, rewardPoints 
        /// </summary>    
        [DisplayName("Setting")]
        public string Setting { get; set; }
        [DisplayName("Value")]
        public string Value { get; set; }

    }
}

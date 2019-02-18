using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sup.Helpers
{
    public class UserSetting
    {
        public string Name { set; get; }
        public string Label { set; get; }
        public string Type { get; set; }
        public SelectList Options { get; set; }
        public string Value { set; get; }
    }
}
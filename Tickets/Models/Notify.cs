using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Tickets.Models;
public class Notify
{
    public string? GroupId{ get; set; }
    public string? ItemRole { get; set; } = "Responsible Group";
    public string? Name { get; set; }
    public string? Initials { get; set; } = null;
    public string? Value { get; set; }
    public string? RefValue { get; set; }
    public string? ProfileImageFileName { get; set; } = null;
}

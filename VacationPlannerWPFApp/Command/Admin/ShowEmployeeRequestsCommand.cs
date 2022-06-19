using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using VacationPlannerWPFApp.Models.Admin;
using VacationPlannerWPFApp.ViewModels.Admin;

namespace VacationPlannerWPFApp.Command.Admin;
 /// <summary>
 /// ??????????????????
 /// </summary>
internal class ShowEmployeeRequestsCommand : CommandBase
{
    private ShowEmployeeRequestModel _employeeRequests;
    private ShowEmployeeRequestsViewModel _vm;
    public ShowEmployeeRequestsCommand(ShowEmployeeRequestModel employeeRequests, ShowEmployeeRequestsViewModel vm)
    {
        _employeeRequests = employeeRequests;
        _vm = vm;
    }
    public override void Execute(object? parameter) { }

}
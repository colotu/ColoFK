using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSWL.Accounts.Bus;
using YSWL.MALL.BLL.JLT;
using YSWL.Components.Handlers.API;
using YSWL.Json;
using YSWL.Json.RPC;

namespace YSWL.MALL.API.Sales.v1.v1
{
    //业务员考勤
    public partial class SalesHandler
    {
        //private YSWL.MALL.BLL.JLT.UserAttendance userAttend = new UserAttendance();
        //private  YSWL.MALL.BLL.JLT.AttendanceType typeBll=new AttendanceType();
        //private YSWL.MALL.BLL.JLT.Reports reportBll = new Reports();

        //#region 考勤类型
        //[JsonRpcMethod("GetDutyTypes", Idempotent = true)]
        //[JsonRpcHelp("考勤类型")]
        //public JsonObject GetDutyTypes()
        //{
        //    JsonArray result = new JsonArray();
        //    JsonObject json = null;
        //    List<YSWL.MALL.Model.JLT.AttendanceType> typeList=  typeBll.GetModelList(" Status=1");
        //    foreach (var item in typeList)
        //    {
        //        json = new JsonObject();
        //        json.Put("typeId", item.TypeID);
        //        json.Put("name", item.TypeName);
        //        json.Put("sequence", item.Sequence);
        //        result.Add(json);
        //    }
        //    return new Result(ResultStatus.Success, result);
        //}
        //#endregion

        //#region 添加考勤
        //[JsonRpcMethod("AddAttend", Idempotent = true)]
        //[JsonRpcHelp("添加考勤")]
        //public JsonObject AddAttend(int UserId,int TypeId,string Latitude, string Longitude, string Remark)
        //{
        //    JsonObject json = new JsonObject();
           
        //    YSWL.MALL.Model.JLT.UserAttendance attendModel=new Model.JLT.UserAttendance();
        //    YSWL.Accounts.Bus.User currentUser=new User(UserId);
        //    if (String.IsNullOrWhiteSpace(currentUser.UserName))
        //    {
        //            return new Result(ResultStatus.Failed, "userIllegal"); //用户非法
        //    }

        //    attendModel.UserID = UserId;
        //    attendModel.Status = 1;
        //    attendModel.Remark = Remark;
        //    attendModel.Latitude = Latitude;
        //    attendModel.Longitude = Longitude;
        //    attendModel.TypeID = TypeId;
        //    attendModel.UserName = currentUser.UserName;
        //    attendModel.TrueName = currentUser.TrueName;
        //    attendModel.CreatedDate = DateTime.Now;
        //    attendModel.AttendanceDate = DateTime.Now.Date;
        //    int resultId=userAttend.Add(attendModel);
        //    if (resultId > 0)
        //    {
        //        return new Result(ResultStatus.Success, resultId);
        //    }
        //    else
        //    {
        //        return new Result(ResultStatus.Failed, "添加考勤失败");
        //    }
        //}
        //#endregion 

        //#region 添加日报
        //[JsonRpcMethod("AddReport", Idempotent = true)]
        //[JsonRpcHelp("添加日报")]
        //public JsonObject AddReport(int UserId, string Title,string Content)
        //{

        //    YSWL.MALL.Model.JLT.Reports reportModel = new Model.JLT.Reports();
        //    YSWL.Accounts.Bus.User currentUser = new User(UserId);
        //    if (String.IsNullOrWhiteSpace(currentUser.UserName))
        //    {
        //        return new Result(ResultStatus.Failed, "userIllegal"); //用户非法
        //    }

        //    reportModel.Content = Content;
        //    reportModel.Status = 0;
        //    reportModel.Title = Title;
        //    reportModel.Type = 0;
        //    reportModel.UserId = UserId;
        //    reportModel.CreatedDate = DateTime.Now;
        //    reportModel.ReportDate = DateTime.Now.Date;
        //    int resultId = reportBll.Add(reportModel);
        //    if (resultId > 0)
        //    {
        //        return new Result(ResultStatus.Success, resultId);
        //    }
        //    else
        //    {
        //        return new Result(ResultStatus.Failed, "添加考勤失败");
        //    }
        //}
        //#endregion 

        //#region 获取日报列表
        //[JsonRpcMethod("GetRePorts", Idempotent = true)]
        //[JsonRpcHelp("获取日报列表")]
        //public JsonObject GetRePorts(int UserId, string keyWord, int page = 1, int pageNum = 10)
        //{
        //    YSWL.MALL.Model.JLT.Reports reportModel = new Model.JLT.Reports();
        //    YSWL.Accounts.Bus.User currentUser = new User(UserId);
           
        //    if (pageNum == 0)
        //    {
        //        pageNum = 10;
        //    }
        //    if (String.IsNullOrEmpty(page.ToString()))
        //    {
        //        page = 1;
        //    }
        //    //重置页面索引
        //    page = page > 1 ? page : 1;
        //    //计算分页起始索引
        //    int startIndex = page > 1 ? (page - 1) * pageNum + 1 : 0;
        //    //计算分页结束索引
        //    int endIndex = page > 1 ? startIndex + pageNum - 1 : pageNum;

        //    StringBuilder strWhere = new StringBuilder();
        //    strWhere.AppendFormat(" UserId= {0}", UserId);
        //    if (!String.IsNullOrWhiteSpace(keyWord))
        //    {
        //        strWhere.AppendFormat(" and  (Title like %{0}% or Content like %{0}%)", keyWord);
        //    }

        //    if (String.IsNullOrWhiteSpace(currentUser.UserName))
        //    {
        //        return new Result(ResultStatus.Failed, "userIllegal"); //用户非法
        //    }
        //    int toalCount = reportBll.GetRecordCount(strWhere.ToString());
        //    JsonArray result = new JsonArray();
        //    JsonObject json = null;
        //    List<YSWL.MALL.Model.JLT.Reports> reportsList = reportBll.GetModelListByPage(strWhere.ToString(), "CreatedDate desc", startIndex, endIndex);

        //    foreach (var item in reportsList)
        //    {
        //        json = new JsonObject();
        //        json.Put("reportid", item.ID);
        //        json.Put("title", item.Title);
        //        json.Put("time", item.CreatedDate.ToString("yyyy-MM-dd"));
        //        json.Put("status", item.Status);
        //        json.Put("content", item.Content);
        //        result.Add(json);
        //    }
        //    return new Result(ResultStatus.Success, result);
          
        //}
        //#endregion 
    }
}

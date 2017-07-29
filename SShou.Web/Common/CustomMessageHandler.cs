using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using SShou.UserRecommend;
using SShou.UserRecommend.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SShou.Web.Common
{
    public partial class CustomMessageHandler : MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>>
    {
        readonly string[] SplitChar = { "P|" };

        public IUserRecommendApplicationService AppService { get; set; }


        public CustomMessageHandler(Stream inputStream, int maxRecordCount = 0)
            : base(inputStream, null, maxRecordCount)
        {
            WeixinContext.ExpireMinutes = 3;
        }
        public override void OnExecuting()
        {
            //测试MessageContext.StorageData
            if (CurrentMessageContext.StorageData == null)
            {
                CurrentMessageContext.StorageData = 0;
            }
            base.OnExecuting();
        }
        public override void OnExecuted()
        {
            base.OnExecuted();
            CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            //所有没有被处理的消息会默认返回这里的结果
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "亲！暂时没有特殊服务哟，我们将尽快推出一些便民操作";
            return responseMessage;
        }

        /// <summary>
        /// 订阅（关注）事件
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            //requestMessage.
            string eventKey = requestMessage.EventKey;
            if (!string.IsNullOrEmpty(eventKey))
            {
                string[] userInfo = eventKey.Split(SplitChar, StringSplitOptions.None);
                UserRecommendInputDto input = new UserRecommendInputDto();
                input.Recommended = requestMessage.FromUserName;
                input.Recommender = userInfo[1];
                input.Score = Common.CommonConst.InvitScore;
                input.RecommenderId = int.Parse(userInfo[0]);
                this.AppService.AddUserRecommend(input);
            }
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = "欢迎订阅";
            return responseMessage;
        }

        /// <summary>
        /// 退订
        /// 实际上用户无法收到非订阅账号的消息，所以这里可以随便写。
        /// unsubscribe事件的意义在于及时删除网站应用中已经记录的OpenID绑定，消除冗余数据。并且关注用户流失的情况。
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "有空再来";
            return responseMessage;
        }



        public override IResponseMessageBase OnEvent_ScanRequest(RequestMessageEvent_Scan requestMessage)
        {
            //string eventKey = requestMessage.EventKey;
            //if (!string.IsNullOrEmpty(eventKey))
            //{
            //    string[] userInfo = eventKey.Split(SplitChar, StringSplitOptions.None);
            //    UserRecommendInputDto input = new UserRecommendInputDto();
            //    input.Recommended = requestMessage.FromUserName;
            //    input.Recommender = userInfo[1];
            //    input.RecommenderId = int.Parse(userInfo[0]);
            //    this.AppService.AddUserRecommend(input);
            //}
            //通过扫描关注
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "通过扫描关注。";
            return responseMessage;
        }

        public override IResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
        {
            //这里是微信客户端（通过微信服务器）自动发送过来的位置信息
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "这里写什么都无所谓，比如：上帝爱你！";
            return responseMessage;//这里也可以返回null（需要注意写日志时候null的问题）
        }


    }
}
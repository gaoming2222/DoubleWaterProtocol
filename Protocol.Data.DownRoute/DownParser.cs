﻿using Hydrology.Entity;
using Protocol.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Protocol.Data.DownRoute
{
    public class DownParser : IDown
    {
        public IDown Down { get; set; }
        //  数据下行读取
        public String BuildQuery(string sid, IList<EDownParam> cmds, EChannelType ctype)
        {
            String result = String.Empty;
            String dataProtocol = Manager.XmlStationData.Instance.GetProtocolBySId(sid);
            if (dataProtocol == "RG30")
            {
                Down = new Data.RG30.DownParser();
            }
            //时差法
            if (dataProtocol == "TDXY")
            {
                Down = new Data.TDXY.DownParser();
            }
            result = Down.BuildQuery(sid, cmds, ctype);
            return result;
        }

        //  数据下行设置
        public String BuildSet(string sid, IList<EDownParam> cmds, CDownConf down, EChannelType ctype)
        {
            return "";
        }

        //  批量数据Flash下行
        public String BuildQuery_Flash(string sid, EStationType stationType, ETrans trans, DateTime beginTime, DateTime endTime, EChannelType ctype)
        {

            return "";
        }

        //  批量数据主板下行
        public String BuildQuery_Batch(string sid, ETrans trans, DateTime beginTime, EChannelType ctype)
        {
            return null;
        }

        /// <summary>
        /// 批量传输sd卡
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="trans"></param>
        /// <param name="beginTime"></param>
        /// <param name="ctype"></param>
        /// <returns></returns>
        public String BuildQuery_SD(string sid, DateTime beginTime, EChannelType ctype)
        {
            return "";
        }

        //  数据下行解析
        public bool Parse(string msg, out CDownConf downConf)
        {
            downConf = null;
            return true;
        }

        //  批量数据flash下行解析
        public bool Parse_Flash(String msg, EChannelType ctype, out CBatchStruct batch)
        {
            batch = null;
            return false;
        }

        //  数据批量主板下行解析
        public bool Parse_Batch(String msg, out CBatchStruct batch)
        {
            batch = null;
            return false;
        }

        public bool Parse_SD(String rawMsg, string id, out CSDStruct sd)
        {
            sd = null;
            return false;
        }

    }
}
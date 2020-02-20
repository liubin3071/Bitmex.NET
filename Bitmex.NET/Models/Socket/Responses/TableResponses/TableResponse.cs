using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;

namespace Bitmex.NET.Models.Socket.Responses.TableResponses
{
    //public class TableResponse : TableResponse<JsonElement>
    //{
    //    public static bool TryHandle(JsonElement response, Action<TableResponse> action)
    //    {
    //        if (response.TryGetProperty("table", out var table)
    //            && Enum.TryParse(table.GetString(), out SubscriptionType _))
    //        {
    //            var tableResponse = BitmexJsonSerializer.Deserialize<TableResponse>(response);
    //            action?.Invoke(tableResponse);
    //            return true;
    //        }
    //        return false;
    //    }
    //}

    public class TableResponse<T>
    {
        public static bool TryHandle(JsonElement response, Action<TableResponse<T>> action, SubscriptionType subscriptionType)
        {
            if (response.TryGetProperty("table", out var table)
                && Enum.TryParse(table.GetString(), true, result: out SubscriptionType subscription)
                && subscription == subscriptionType)
            {
                var tableResponse = BitmexJsonSerializer.Deserialize<TableResponse<T>>(response);
                action?.Invoke(tableResponse);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Table name / Subscription topic.
        /// 数据表名/订阅主题
        /// Could be "trade", "order", "instrument", etc.
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// The type of the message. Types:
        /// 'partial'; This is a table image, replace your data entirely.
        /// 'update': Update a single row.
        /// 'insert': Insert a new row.
        /// 'delete': Delete a row.
        /// </summary>
        public BitmexActions Action { get; set; }

        /// <summary>
        /// 数据行
        /// </summary>
        public T[] Data { get; set; }

        /// <summary>
        /// Attribute names that are guaranteed to be unique per object.
        /// If more than one is provided, the key is composite.
        /// Use these key names to uniquely identify rows. Key columns are guaranteed
        /// to be present on all data received.
        /// </summary>
        public string[] Keys { get; set; }

        /// <summary>
        /// This lists key relationships with other tables.
        /// For example, `quote`'s foreign key is {"symbol": "instrument"}
        /// </summary>
        public JsonElement ForeignKeys { get; set; }

        /// <summary>
        /// This lists the shape of the table. The possible types:
        /// "symbol" - In most languages this is equal to "string"
        /// "guid"
        /// "timestamp"
        /// "timespan"
        /// "float"
        /// "long"
        /// "integer"
        /// "boolean"
        /// </summary>
        public JsonElement Types { get; set; }

        /// <summary>
        /// When multiple subscriptions are active to the same table, use the `filter` to correlate which datagram
        /// belongs to which subscription, as the `table` property will not contain the subscription's symbol.
        /// </summary>
        public JsonElement Filter { get; set; }

        /// <summary>
        /// These are internal fields that indicate how responses are sorted and grouped.
        /// </summary>
        public JsonElement Attributes { get; set; }
    }
}
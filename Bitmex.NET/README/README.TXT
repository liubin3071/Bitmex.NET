订阅

1 {"op": "subscribe", "args": ["tradeBin1h:XBTUSD"]}
2 {"op": "subscribe", "args": ["tradeBin1h"]}
3 {"op": "unsubscribe", "args": ["tradeBin1h:XBTUSD"]}
4 {"op": "unsubscribe", "args": ["tradeBin1h"]}


先带参数订阅，后不带参数订阅可覆盖
若先不带参数订阅，若再次订阅发生错误

1=>2 正常

1=>2=>3 错误，说明Filter被覆盖
{"status":400,"error":"Not subscribed to tradeBin1h:XBTUSD.","meta":{},"request":{"op":"unsubscribe","args":["tradeBin1h:XBTUSD"]}}

2=>1 发生错误
{"status":400,"error":"You are already subscribed to this topic: tradeBin1h:XBTUSD","meta":{},"request":{"op":"subscribe","args":["tradeBin1h:XBTUSD"]}}

//尽量不要合并订阅，每次订阅一个主题
//订阅主题数组，存在一个错误，其他主题成功订阅，但不返回成功结果

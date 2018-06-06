# RealFriend API 文档
- acmore
- 2018.5.31

## 0. API
#### 0.1 API列表
直接访问[后端地址][backend_url]就能看到后端的API列表，这份列表是基于`django-rest-framework`自动生成的，基本包含了所有的API，部分API未被检测到，也会在下边单独列出。

**对于访问的任何API接口，都要在其后加上`?format=json`这样才能得到Json风格的返回值。**

下边的文档中任何接口的请求都有返回值，其中在[后端地址][backend_url]能看到的接口地址都是固定的，在浏览器访问试一下就能清楚。对于[后端地址][backend_url]上没有的，我会单独写明。

#### 0.2 如何访问
关于Rest风格的接口，基本操作有四种：
- get：获取操作
- update/patch：更新操作
- post/put：新增操作
- delete：删除操作

反映在具体的编程中，patch和put都可以用post完成，一些比较现代化的网络请求工具会直接提供这四种甚至更多的方法。

#### 0.3 关于参数
在一般的网络请求中，url定位资源有几种形式，分别如下：
- 方法请求
	- 即使是同样的路径，使用不同的方法请求可能会有不同的效果，如对同一个用户使用GET和DELETE方法显然结果是不同的
- 路径请求
	- 可以把参数隐含才url路径中，如/user/acmore，这里的`acmore`就是一个变量，可以变换其内容来获取不同的用户信息，相应的`acmore`就叫路径参数，在下边的API文档中，需要路径参数的会用`{}`标明，如`/user/{username}`
- 参数请求
	- 这是最经典和常用的一种请求方式，对于不同的方法有不同的参数形式，分别如下：
		- GET：直接在url后附上`?key1=value1&key2=value2...`的请求参数
		- POST：在请求url的时候使用附加数据将json风格的键值对发送给服务器
	- 以上两种形式区别之一在于url的长度是有限制的，所以GET参数不能过长，而POST就没有这个限制

#### 0.4 易混淆点
- `username`和`nickname`不一样，前者相当于微信号，唯一且固定，后者相当于微信昵称，随时可变


## 1. User
| 名称 | 地址 | 方法 | 参数 | 说明 |
| :-: | :-: | :-: | :-: | :-: |
| 获取用户列表 | `/user` | GET | 无 | 这是后台检测状态的API，客户端用不到 |
| 获取用户信息 | `/user/{username}` | GET/UPDATE | GET:无/UPDATE:具体的内容见[后端地址][backend_url] | 获取用户详细信息的API，同时使用UPDATE方法可以更新用户信息（只需要保持用户id不变） |
| 获取用户关注的用户 | `/user/{username}/followees` | GET | 无 | 获取用户关注的人（而不是粉丝） |
| 获取用户的粉丝 | `/user/{username}/followers` | GET | 无 | 获取用户的粉丝（关注用户的人） |
| 获取用户和另一位用户的友好度 | `/user/{username}/friendship/{friend_username}` | GET/UPDATE | 无 | 获取用户名为`username`的用户和用户名为`friend_username`的用户之间的友好度，并且可以通过这个接口来更新数值 |
| 创建新用户 | `/user/create` | PUT | 具体参数见[后端地址][backend_url]，其中的`followers`/`followees`/`info`/`create_time`这四个字段不用填，后端会自动创建 | 这是用户注册时使用的接口，如果请求成功则说明用户注册成功，否则说明失败，具体的失败信息现在还没做 |
| 登录验证（[后端地址][backend_url]没有） | `/user/login` | POST | {<br />`username`: 用户名,<br />`password`: 用户密码<br />}<br /><br />返回值是`{"status": "success"}`或`{"status": "password wrong"}`或`{"status": "user not exists"}` | 用户的登录验证，返回三种状态分别表示登录成功、用户密码错误以及用户不存在 |
| 关注好友（[后端地址][backend_url]没有） | `/user/{username}/follow/{friend_username}` | 不限，最好是POST。如果成功，返回值是`{"status": "success"}`，否则直接抛出异常 | 无 | 用户名为`username`的用户关注用户名为`friend_username`的用户 |

## 2. Activity
| 名称 | 地址 | 方法 | 参数 | 说明 |
| :-: | :-: | :-: | :-: | :-: |
| 获取活动列表 | `/activity` | GET | 无 | 获取所有的活动列表，按照时间排序，首页可以使用 |
| 获取活动详情 | `/activity/{activity_id}` | GET/UPDATE | GET:无/UPDATE:具体的内容见[后端地址][backend_url] | 获取活动的详细信息，也可以通过这个接口更新活动内容 |
| 创建新的活动 | `/activity/create` | PUT | 具体参数见[后端地址][backend_url]，其中的`create_time`这个字段不用填，后端会自动创建，其中`participants`是上传一个用户id的列表 | 通过这个接口来创建新的活动 |
| 发表评论 | `/activity/{activity_id}/comment` | POST | {<br />`nickname`: 用户昵称,<br />`username`: 用户名,<br />`content`: 评论内容<br />}<br /><br />返回值是`{"status": "success", "comment_id": 新评论的id}` | 用户在某个活动下发表评论 |
| 获取评论列表 | `/activity/{activity_id}/comments` | GET | 无。返回值是一个列表，列表的每个元素是一个comment实例，其内容为<br />{<br />`id`: 评论id,<br />`nickname`: 评论者的用户昵称,<br />`username`: 评论者的用户名<br />`content`: 评论者的评论内容,<br />`create_at`: 评论发表时间<br />} | 获取某个活动下的评论列表 |

## 3. Game
| 名称 | 地址 | 方法 | 参数 | 说明 |
| :-: | :-: | :-: | :-: | :-: |
| 获取游戏列表 | `/game` | GET | 无 | 获取所有的游戏列表，按照时间排序，首页可以使用 |
| 获取游戏详情 | `/game/{game_id}` | GET/UPDATE | GET:无/UPDATE:具体的内容见[后端地址][backend_url] | 获取游戏详情，并且可以更新游戏的内容 |
| 创建新的游戏 | `/game/create` | PUT | 具体参数见[后端地址][backend_url] | 通过这个接口来创建新的游戏 |

## 4. Message
| 名称 | 地址 | 方法 | 参数 | 说明 |
| :-: | :-: | :-: | :-: | :-: |
| 获取消息列表 | `/message` | GET | ?username={username} | 获取某个用户所有的消息列表，按照时间排序 |
| 获取消息详情 | `/message/{message_id}` | GET/UPDATE | GET:无/UPDATE:具体的内容见[后端地址][backend_url] | 获取消息详情，并且可以更新消息的内容 |
| 创建新的消息 | `/message/create` | PUT | 具体参数见[后端地址][backend_url] | 通过这个接口来创建新的消息 |
| 将消息标记为已读 | `/message/read/{message_id}` | GET | 无。返回值是`{"status": "success"}` | 进入消息详情时请求这个接口，将消息标记为已读 |

## 5. Merchant
| 名称 | 地址 | 方法 | 参数 | 说明 |
| :-: | :-: | :-: | :-: | :-: |
| 获取商家列表 | `/merchant` | GET | 无 | 获取所有的商家列表 |
| 获取商家详情 | `/merchant/{merchant_id}` | GET/UPDATE | GET:无/UPDATE:具体的内容见[后端地址][backend_url] | 获取商家详情，并且可以更新商家的内容 |
| 创建新的商家 | `/merchant/create` | PUT | 具体参数见[后端地址][backend_url] | 通过这个接口来创建新的商家 |

## 6. Token
| 名称 | 地址 | 方法 | 参数 | 说明 |
| :-: | :-: | :-: | :-: | :-: |
| 获取身份令牌（可用，但是目前不需要用） | `/token` | POST |  {<br />`username`: 权限用户的用户名,<br />`password`: 权限用户的密码<br />}<br /><br />返回值是<br />{<br />`status`: "success",<br />`token`: 有效的令牌<br />} | 将权限用户的登录口令POST上来之后就能得到令牌，然后请求消息的时候加在消息头中，才可以访问数据（目前没有在这里设限，所以不需要获取令牌就能直接访问） |

---
[backend_url]:http://real.chinanorth.cloudapp.chinacloudapi.cn/
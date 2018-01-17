const HUBNAME = 'hubs';

// 客户端调用服务器端方法*/
// 更新订单打印次数
// const updateOrderPrint = {
//   name: 'updateOrderPrint',
//   method: data => console.log(data)
// }

// 服务器调用客户端方法*/
// 打印新订单
const printNewOrder = {
  name: 'printNewOrder',
  method: data => {
    console.log(data)
  }
}
const get = {
  name: 'Get',
  method: data => {
    console.log(data)
  }
}

// 服务器端的方法
// const serverMethodSets = [updateOrderPrint];
// 客户端的方法
const clientMethodSets = [printNewOrder, get]; // 将需要注册的方法放进集合
// 手动创建proxy
export function createHubProxy(hub) {
  const proxy = hub.createHubProxy(HUBNAME)
  // 注册客户端方法
  clientMethodSets.map(item => {
    proxy.on(item.name, item.method)
    return null;
  })
  return proxy
}
// 建立连接
export function startConnection() {
  const hub = $.hubConnection("http://103.45.8.198")
  const proxy = createHubProxy(hub) // 需要先注册方法再连接
  hub.start().done(connection => {
    console.log('Now connected, connection ID=' + connection.id)
  }).fail(() => {
    console.log('Could not connect');
  })
  hub.error(error => {
    console.log('SignalR error: ' + error)
  })
  hub.connectionSlow(() => {
    console.log('We are currently experiencing difficulties with the connection.')
  });
  hub.disconnected(() => {
    console.log('disconnected')
  });
  return proxy
}


<template>
   <div>
    <ul>
      <li v-for="item in messages">
        {{item.Message}}
      </li>
    </ul>
  </div>
</template>



<script>
import "signalr";
export default {
  name: "hub",
  data() {
    return {
      client: null,
      messages: []
    };
  },
  methods: {
    get() {
      const connection = $.hubConnection("http://103.45.8.198");
      // 如果前后端为同一个端口，可不填参数。如果前后端分离，这里参数为服务器端的URL
      const demoChatHubProxy = connection.createHubProxy("hubs");
      demoChatHubProxy.on("Send", (userName, message) => {
        console.log(userName + " " + message);
      });
      connection
        .start()
        .done(() => {
          console.log("Now connected, connection ID=" + connection.id);
        })
        .fail(() => {
          console.log("Could not connect");
        });
    }
  },
  created() {
    this.get();
  }
};
</script>

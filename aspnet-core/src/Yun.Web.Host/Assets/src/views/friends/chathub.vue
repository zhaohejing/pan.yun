
<template>
   <div>

  </div>
</template>



<script>
import signalR from "signalr-client";
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
      debugger;
      const client = new signalR.client(
        "http://103.45.8.198/signalR", // signalR service URL
        ["hubs"], // array of hubs to be supported in the connection
        2, // optional: retry timeout in seconds (default: 10)
        true // optional: doNotStart default false
      );
      client.handlers.testhub = {
        // hub name must be all lower case.
        addmessage: (name, message) => {
          // method name must be all lower case, function signature should match call from hub
          console.log("revc => " + name + ": " + message);
        }
      };
      client.start();
    }
  },
  created() {
    this.get();
  }
};

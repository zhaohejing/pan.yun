
<template>
  <div>
     <h1 id="head1"></h1>
    <div>
        <select id="formatType">
            <option value="json">json</option>
            <option value="line">line</option>
        </select>

        <input type="button" id="connect" value="Connect" />
        <input type="button" id="disconnect" value="Disconnect" />
    </div>


    <h4>To Everybody</h4>
    <form class="form-inline">
        <div class="input-append">
            <input type="text" id="message-text" placeholder="Type a message, name or group" />
            <input type="button" id="broadcast" class="btn" value="Broadcast" />
            <input type="button" id="broadcast-exceptme" class="btn" value="Broadcast (All Except Me)" />
            <input type="button" id="join" class="btn" value="Enter Name" />
            <input type="button" id="join-group" class="btn" value="Join Group" />
            <input type="button" id="leave-group" class="btn" value="Leave Group" />
        </div>
    </form>

    <h4>To Me</h4>
    <form class="form-inline">
        <div class="input-append">
            <input type="text" id="me-message-text" placeholder="Type a message" />
            <input type="button" id="send" class="btn" value="Send to me" />
        </div>
    </form>

    <h4>Private Message</h4>
    <form class="form-inline">
        <div class="input-prepend input-append">
            <input type="text" name="private-message" id="private-message-text" placeholder="Type a message" />
            <input type="text" name="user" id="target" placeholder="Type a user or group name" />

            <input type="button" id="privatemsg" class="btn" value="Send to user" />
            <input type="button" id="groupmsg" class="btn" value="Send to group" />
        </div>
    </form>
    <ul id="message-list"></ul>
  </div>
</template>



<script>
import $ from "jquery";
import signalR from "signalr";
export default {
  name: "hub",
  data() {
    return {
      client: null
    };
  },
  methods: {},
  created() {
    debugger;
    this.client = new signalR.client(
      `${process.env.BASE_API}/hubs`, // signalR service URL
      ["hubs"], // array of hubs to be supported in the connection
      2, // optional: retry timeout in seconds (default: 10)
      true // optional: doNotStart default false
    );

    this.client.handlers.testhub = {
      // hub name must be all lower case.
      addmessage: (name, message) => {
        // method name must be all lower case, function signature should match call from hub
        console.log("revc => " + name + ": " + message);
      }
    };

    // ==== Optional function bindings to these names will allow for handling of these system events.

    this.client.serviceHandlers = {
      // Yep, I even added the merge syntax here.
      bound: () => {
        console.log("Websocket bound");
      },
      connectFailed: error => {
        console.log("Websocket connectFailed: ", error);
      },
      connected: connection => {
        console.log(connection);
        console.log("Websocket connected");
      },
      disconnected: () => {
        console.log("Websocket disconnected");
      },
      onerror: error => {
        console.log("Websocket onerror: ", error);
      },
      messageReceived: message => {
        console.log("Websocket messageReceived: ", message);
        return false;
      },
      bindingError: error => {
        console.log("Websocket bindingError: ", error);
      },
      connectionLost: error => {
        console.log("Connection Lost: ", error);
      },
      reconnecting: retry => {
        console.log("Websocket Retrying: ", retry);
        // return retry.count >= 3; /* cancel retry true */
        return true;
      }
    };

    // Handle Authentication
    this.client.serviceHandlers.onUnauthorized = res => {
      console.log(res);

      console.log("Websocket onUnauthorized:");
    };

    // ### Calling methods on the signalR hub

    // #### From the client instance
    setInterval(function() {
      console.log(this.client.state);
      client.invoke(
        "TestHub", // Hub Name (case insensitive)
        "Send", // Method Name (case insensitive)
        "client",
        "invoked from client" // additional parameters to match called signature
      );
    }, 2000);
    const send = () => {
      console.log("Client State Code: ", this.client.state.code);
      console.log("Client State Description: ", this.client.state.desc);
      console.log("==>> try to get hub");
      const hub = this.client.hub("TestHub"); // Hub Name (case insensitive)

      // if not bound set the hub will be undefined
      if (!hub) {
        console.log("==>> hub not found. retry in 10 seconds");
        setTimeout(sendMessage, 10000);
        return;
      }
      console.log("==>> send message");
      hub.invoke(
        "Send", // Method Name (case insensitive)
        "hub",
        "invoked from hub" // additional parameters to match called signature
      );
    };
    // #### From the hub instance
    setTimeout(() => {
      send();
    }, 3000);

    console.log("Waiting!");
    process.stdin.resume();

    setTimeout(function() {
      // explicitly disconnect
      this.client.end();
    }, 1500);

    // Manually Start Client
    this.client.start();
  }
};
</script>

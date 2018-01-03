<template>
  <div>
    <mu-flexbox>
      <mu-flexbox-item class="flex-demo">
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
        <mu-paper class="demo-paper" :zDepth="2" />
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
      </mu-flexbox-item>
    </mu-flexbox>
    <mu-divider />

    <div class="login-container">
      <mu-text-field hintText="账户" v-model="model.userName" type="text" icon="phone" />
      <br/>
      <mu-text-field hintText="密码" v-model="model.password" type="password" icon="phone" />
      <br/>
      <mu-text-field hintText="昵称" v-model="model.name" type="text" icon="phone" />
      <br/>
      <mu-text-field hintText="邮箱" v-model="model.emailAddress" type="text" icon="phone" />
      <br/>

    </div>

    <mu-flexbox>
      <mu-flexbox-item>
        <mu-raised-button class="demo-raised-button" @click="dore" label="注册" backgroundColor="#80deea" />
      </mu-flexbox-item>
      <mu-flexbox-item>
        <mu-raised-button class="demo-raised-button" @click="back" label="返回" backgroundColor="#d1c4e9" />
      </mu-flexbox-item>
    </mu-flexbox>
  </div>

</template>

<script>
import { register } from "api/login";
export default {
  data() {
    return {
      model: {
        name: "",
        userName: "",
        emailAddress: "",
        password: "",
        headImageUrl: ""
      }
    };
  },
  methods: {
    dore() {
      register(this.model)
        .then(r => {
          if (r && r.result) {
            this.$router.push({
              path: "/login"
            });
          } else {
            console.log(r);
          }
        })
        .catch(e => {
          console.log(e);
        });
    },
    back() {
      this.$router.push({
        path: "/login"
      });
    }
  }
};
</script>
<style scopd>
.demo-paper {
  display: inline-block;
  height: 100px;
  width: 100px;
  margin-top: 40px;
  margin-bottom: 40px;
  text-align: center;
}

.login-container {
  margin-top: 30px;
}

.demo-raised-button-container {
  display: flex;
  align-items: center;
  flex-wrap: wrap;
}

.demo-raised-button {
  margin: 12px;
  margin-left: 20px;
}
</style>

<template>
<div>
    <mu-select-field v-model="model.categoryId" :labelFocusClass="['label-foucs']" label="请选择分类">
    <mu-menu-item v-for="mo,index in list" :key="index" :value="mo.id" :title="mo.cateName" />
  </mu-select-field>
  <mu-text-field hintText="标题" v-model="model.title" type="text" icon="title"/><br/>
  <mu-text-field hintText="内容" v-model="model.content" multiLine :rows="8" :rowsMax="8" icon="textsms"/><br/>
  <mu-flexbox>
    <mu-flexbox-item >
    </mu-flexbox-item>
    <mu-flexbox-item >
   <mu-float-button icon="add" @click="sharesh"  class="demo-float-button"/>
    </mu-flexbox-item>
    <mu-flexbox-item >
    </mu-flexbox-item>
  </mu-flexbox>
</div>
</template>
<script >
import { inserShare, categorys } from "api/share";
export default {
  name: "share",
  data() {
    return {
      list: [],
      model: { id: null, title: "", content: "", categoryId: 0 }
    };
  },
  created() {
    this.init();
  },
  methods: {
    init() {
      categorys({ skipCount: 0, MaxResultCount: 100 }).then(r => {
        if (r && r.result) {
          this.list = r.result.items;
        }
      });
    },
    sharesh() {
      inserShare({ shareEditDto: this.model }).then(r => {
        if (r && r.success) {
          this.$router.push({ path: "/movie" });
        }
      });
    }
  }
};
</script>
<style>
.demo-float-button {
  margin-left: 20px;
}
</style>

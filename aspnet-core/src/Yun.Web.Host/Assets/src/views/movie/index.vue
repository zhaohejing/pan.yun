<template>
  <div class="demo-refresh-container">
    <mu-refresh-control :refreshing="refreshing" :trigger="trigger" @refresh="refresh" />
    <mu-list>
      <mu-sub-header>最新分享</mu-sub-header>
      <mu-list-item @click="gotodetail(item)" :key="index" v-for="item,index in list" :title="'['+ item.categoryName +']'+item.title"
       :describeText="item.time">
        <mu-avatar :src="item.image" slot="leftAvatar" />
        <mu-icon value="details" slot="right" />
      </mu-list-item>
    </mu-list>
     <mu-infinite-scroll :scroller="scroller" :loading="loading" @load="loadMore"/>
  </div>
</template>

<script>
import { shares } from "api/share";
export default {
  data() {
    return {
      list: [],
      num: 10,
      refreshing: false,
      loading: false,
      trigger: null,
      scroller: null,
      current: 1,
      params: { skipCount: 0, maxResultCount: 10, filter: "" }
    };
  },
  created() {
    this.init();
  },
  mounted() {
    this.trigger = this.$el;
    this.scroller = this.$el;
  },
  methods: {
    refresh() {
      this.refreshing = true;
      this.params.skipCount = 0;
      this.init();
      this.refreshing = false;
    },
    loadMore() {
      this.loading = true;
      this.current++;
      this.params.skipCount = (this.current - 1) * this.params.maxResultCount;
      this.more();
      this.loading = false;
    },
    more() {
      shares(this.params)
        .then(r => {
          console.log(r);
          if (r && r.result) {
            this.list.push(r.result.items);
          }
        })
        .catch(e => {
          console.log(e);
          this.$store.dispatch("show", {
            state: true,
            text: e.error.message
          });
        });
    },
    init() {
      shares(this.params)
        .then(r => {
          console.log(r);
          if (r && r.result) {
            this.list = r.result.items;
          }
        })
        .catch(e => {
          this.$store.dispatch("show", {
            state: true,
            text: e.error.message
          });
        });
    },
    gotodetail(item) {
      this.$router.push({ path: "/detail/" + item.id });
    }
  }
};
</script>

<style>
.demo-refresh-container {
  overflow: auto;
  -webkit-overflow-scrolling: touch;
  border: 1px solid #d9d9d9;
  position: relative;
  user-select: none;
}
</style>

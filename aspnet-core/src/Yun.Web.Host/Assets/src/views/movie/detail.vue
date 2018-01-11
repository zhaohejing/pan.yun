<template>
  <div>
    <mu-card>
      <mu-card-header :title="share.author" :subTitle="share.creationTime">
        <mu-avatar src="static/images/uicon.jpg" slot="avatar" />
      </mu-card-header>
       <mu-card-title :title="'['+ share.categoryName +']'+share.title" />
      <mu-card-text>
        {{share.content}} </mu-card-text>
      <mu-card-actions>
        <mu-icon-button icon="thumb_up" />
        <mu-icon-button icon="comment" @click="open"/>
      </mu-card-actions>
    </mu-card>
    <mu-list>
      <mu-list-item @click="userdetail(item)" v-for="item,index in share.comments" :key="index" :title="item.from">
        <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
        <span slot="describe">
          <span style="color: rgba(0, 0, 0, .87)">{{item.creationTime | moment("YYYY/MM/DD HH:mm:ss")  }}</span>
          <br/>
          {{item.content}}
        </span>
      </mu-list-item>
      <mu-divider inset/>
    </mu-list>
    <mu-dialog :open="dialog"  @close="close">
    <mu-text-field multiLine :rows="6" :rowsMax="6"  label="评论" v-model="comment" labelFloat/><br/>
    <mu-flat-button slot="actions" primary @click="save" label="确定"/>
  </mu-dialog>
  </div>

</template>

<script>
import { shareDetail, comment } from "api/share";
export default {
  data() {
    return {
      comment: "",
      dialog: false,
      share: {},
      id: null
    };
  },
  created() {
    this.id = this.$route.params.id;
    this.init();
  },
  methods: {
    userdetail(item) {
      this.$router.push({ path: `/userdetail/${item.creatorUserId}` });
    },
    save() {
      const model = {
        shareId: this.share.id,
        from: "张三",
        fromImage: "",
        content: this.comment
      };
      comment(model).then(r => {
        if (r && r.success) {
          this.dialog = false;
          this.init();
        }
      });
    },
    open() {
      if (!sessionStorage.getItem("token")) {
        this.$router.push({ path: "/login" });
        return;
      }
      this.dialog = true;
    },
    close() {
      this.dialog = false;
    },
    init() {
      shareDetail(this.id)
        .then(r => {
          console.log(r);
          if (r && r.result) {
            this.share = r.result;
          }
        })
        .catch(e => {
          console.log(e);
          this.$store.dispatch("show", {
            state: true,
            text: e.error.message
          });
        });
    }
  }
};
</script>

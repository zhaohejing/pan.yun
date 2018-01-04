<template>
  <div>
    <mu-card>
      <mu-card-header title="Myron Avatar" :subTitle="share.creationTime">
        <mu-avatar src="static/images/uicon.jpg" slot="avatar" />
      </mu-card-header>
       <mu-card-title :title="'['+ share.categoryName +']'+share.title" />
      <mu-card-text>
        {{share.content}} </mu-card-text>
      <mu-card-actions>
        <mu-icon-button icon="thumb_up" />
        <mu-icon-button icon="comment" />
      </mu-card-actions>
    </mu-card>
    <mu-list>
      <mu-list-item v-for="item,index in share.comments" :key="index" :title="item.from">
        <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
        <span slot="describe">
          <span style="color: rgba(0, 0, 0, .87)">{{item.creationTime | moment("YYYY/MM/DD HH:mm:ss")  }}</span>
          <br/>
          {{item.content}}
        </span>
      </mu-list-item>
      <mu-divider inset/>
    </mu-list>
  </div>

</template>

<script>
import { shareDetail } from "api/share";
export default {
  data() {
    return {
      share: {},
      id: null
    };
  },
  created() {
    this.id = this.$route.params.id;
    this.init();
  },
  methods: {
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

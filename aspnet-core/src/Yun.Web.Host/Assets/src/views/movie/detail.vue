<template>
  <div>
    <mu-card>
      <mu-card-header title="Myron Avatar" :subTitle="share.creationTime">
        <mu-avatar src="static/images/uicon.jpg" slot="avatar" />
      </mu-card-header>
      <mu-card-text>
        {{share.content}} </mu-card-text>
      <mu-card-actions>
        <mu-icon-button icon="thumb_up" />
        <mu-icon-button icon="comment" />
      </mu-card-actions>
    </mu-card>
    <mu-list>
      <mu-list-item title="Myron Liu">
        <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
        <span slot="describe">
          <span style="color: rgba(0, 0, 0, .87)">哇去</span>
          <br/> 实在编不下去，这就是个demo
        </span>
      </mu-list-item>
      <mu-divider inset/>
      <mu-list-item title="Myron Liu">
        <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
        <span slot="describe">
          <span style="color: rgba(0, 0, 0, .87)">哇去</span>
          <br/> 实在编不下去，这就是个demo
        </span>
      </mu-list-item>
      <mu-divider inset/>
      <mu-list-item title="Myron Liu">
        <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
        <span slot="describe">
          <span style="color: rgba(0, 0, 0, .87)">哇去</span>
          <br/> 实在编不下去，这就是个demo
        </span>
      </mu-list-item>
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
        });
    }
  }
};
</script>

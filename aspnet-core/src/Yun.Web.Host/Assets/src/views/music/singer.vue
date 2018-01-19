<template>
  <div>
    <mu-flexbox>
      <mu-flexbox-item class="flex-demo">
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
        <mu-paper class="demo-paper" circle :zDepth="2">
          <mu-avatar :size="100" src="static/images/uicon.jpg" />
        </mu-paper>
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
      </mu-flexbox-item>
    </mu-flexbox>
    <mu-divider />

    <div>
      <mu-tabs :value="current" @change="handleTabChange">
        <mu-tab value="songs" title="歌曲" />
        <mu-tab value="info" title="简介" />
      </mu-tabs>
      <div v-if="current === 'songs'">
        <mu-list>
          <mu-list-item title="半岛铁盒">
            <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
            <mu-icon-menu slot="right" icon="more_vert" tooltip="操作">
              <mu-menu-item title="收藏" />
              <mu-menu-item title="播放" />
              <mu-menu-item title="分享" />
            </mu-icon-menu>
          </mu-list-item>
          <mu-divider inset/>
         <mu-list-item title="半岛铁盒">
            <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
            <mu-icon-menu slot="right" icon="more_vert" tooltip="操作">
              <mu-menu-item title="收藏" />
              <mu-menu-item title="播放" />
              <mu-menu-item title="分享" />
            </mu-icon-menu>
          </mu-list-item>
          <mu-divider inset/>
          <mu-list-item title="半岛铁盒">
            <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
            <mu-icon-menu slot="right" icon="more_vert" tooltip="操作">
              <mu-menu-item title="收藏" />
              <mu-menu-item title="播放" />
              <mu-menu-item title="分享" />
            </mu-icon-menu>
          </mu-list-item>
          <mu-divider inset/>

        </mu-list>
      </div>
      <div v-if="current === 'info'">
        <h2>Tab Two</h2>
        <p>
          这是第二个 tab
        </p>
      </div>

    </div>

  </div>

</template>

<script>
export default {
  data() {
    return {
      current: "songs"
    };
  },
  created() {
    console.log(1);
  },
  methods: {
    handleTabChange(val) {
      this.current = val;
    }
  }
};
</script>
<style scopd>
.demo-paper {
  display: inline-block;
  height: 100px;
  width: 100px;
  margin-top: 20px;
  margin-bottom: 20px;
  text-align: center;
}
</style>

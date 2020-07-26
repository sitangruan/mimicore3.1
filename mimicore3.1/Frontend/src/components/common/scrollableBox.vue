<template>
  <div class="scrollableBox"><slot></slot></div>
</template>

<script>
export default {
  name: 'scrollableBox',
};
</script>

<style lang="less" scoped>
.scrollableBox {
  overflow: auto;
}
</style>

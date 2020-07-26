<template>
  <div class="inputContainer">
    <input
      :name="inputName"
      type="text"
      :class="{ hasFocus: this.isFocus || this.innerValue !== '' }"
      @input="onInput"
      @change="$emit('change')"
      @focus="onFocus"
      @blur="onBlur"
      v-model="innerValue"
    /><label :for="inputName" @click="onLabelClick">{{ inputName }}</label>
  </div>
</template>

<script>
export default {
  name: 'coolInput',
  props: {
    inputValue: String,
    inputName: String,
  },
  data() {
    return {
      innerValue: this.inputValue,
      isFocus: false,
    };
  },
  methods: {
    onInput() {
      this.$emit('update:inputValue', this.innerValue);
      this.$emit('input');
    },
    onFocus() {
      this.isFocus = true;
      this.$emit('focus');
    },
    onBlur() {
      this.isFocus = false;
    },
    onLabelClick(event) {
      event.preventDefault();
      this.$el.querySelector('input').focus();
    },
  },
  mounted() {
    const label = this.$el.querySelector('label');
    const input = this.$el.querySelector('input');
    input.style.padding = `0 ${label.clientWidth}px 0 5px`;
  },
};
</script>

<style lang="less" scoped>
.inputContainer {
  display: flex;
  box-sizing: border-box;
  border: 1px solid #979797;
  border-radius: 2px;
  position: relative;
  height: 32px;
  padding: 0;
  min-width: 120px;
  input {
    flex: 1;
    border: 0;
    width: 100%;
    height: 100%;
    font-family: Oswald-Regular;
    font-size: 16px;
  }
  label {
    position: absolute;
    color: #888888;
    padding: 0 5px;
    left: 0px;
    top: 50%;
    white-space: nowrap;
    transform: translateY(-50%);
    transition: all 0.3s ease-in-out;
  }
  input.hasFocus + label {
    left: 100%;
    transform: translate(-100%, -50%);
  }
}
</style>

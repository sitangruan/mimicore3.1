<template>
  <div class="inputContainer">
    <input
      :name="inputName"
      type="text"
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
  computed: {
    labelOnRightPosition() {
      if (typeof this.$el !== 'undefined' && typeof this.$el.querySelector('label') !== 'undefined') {
        const offset = this.$el.clientWidth - this.$el.querySelector('label').clientWidth - this.labelPadding;
        return offset;
      }
      return this.labelPadding;
    },
  },
  data() {
    return {
      innerValue: this.inputValue,
      isFocus: false,
      labelPadding: 5,
    };
  },
  methods: {
    resetLabelPosition() {
      if (this.isFocus || this.inputValue !== '') {
        this.$el.querySelector('label').style.left = `${this.labelOnRightPosition}px`;
      } else {
        this.$el.querySelector('label').style.left = `${this.labelPadding}px`;
      }
    },
    onInput() {
      this.$emit('update:inputValue', this.innerValue);
      this.$emit('input');
    },
    onFocus() {
      this.isFocus = true;
      this.resetLabelPosition();
      this.$emit('focus');
    },
    onBlur() {
      this.isFocus = false;
      this.resetLabelPosition();
    },
    onLabelClick(event) {
      event.preventDefault();
      this.$el.querySelector('input').focus();
    },
  },
  mounted() {
    const label = this.$el.querySelector('label');
    const input = this.$el.querySelector('input');
    input.style.padding = `0 ${label.clientWidth + this.labelPadding}px 0 ${this.labelPadding}px`;

    this.resetLabelPosition();
  },
};
</script>

<style lang="less" scoped>
.inputContainer {
  display: flex;
  box-sizing: border-box;
  border: 1px solid #c7c7c7;
  border-radius: 2px;
  position: relative;
  min-height: 28px;
  min-width: 300px;
  input {
    flex: 1;
    border: 0;
    width: 100%;
    min-height: 28px;
    height: 100%;
    font-family: Oswald-Regular;
    &:focus {
      border: 0;
    }
  }
  label {
    position: absolute;
    color: #888888;
    transition: all 0.3s ease-in-out;
  }
}
</style>

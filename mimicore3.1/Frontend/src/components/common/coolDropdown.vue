<template>
  <div class="coolDropdownContainer">
    <div class="selectedResult" @click="toggleExpand()">
      <div class="text" :class="{ tip: !hasSelectedValue }">
        <span class="ellipsisText">{{ selectedText }}</span>
      </div>
      <div class="arrowDown" :class="isExpanded ? 'up' : ''"></div>
    </div>
    <transition name="fade">
      <div class="dropdownListContainer" v-if="isExpanded" v-click-outside="clickOutsideDropdownContainer">
        <div class="searchContainer">
          <div class="valueContainer">
            <input type="text" class="value" v-model="searchText" />
            <div class="cleanIcon" title="Clean" @click="clearSearch()"></div>
          </div>
          <div class="searchIcon" title="Search"></div>
        </div>
        <scrollable-box class="dropdownItemsContainer">
          <div
            class="dropdownItem"
            v-for="option in options"
            :key="option[optionValueField]"
            v-if="isOptionVisible(option)"
          >
            <div
              class="optionContainer"
              @click="onClickOption(option)"
              :class="[isOptionDisabled(option) ? 'isDisabled' : '', checkIsOptionSelected(option) ? 'selected' : '']"
            >
              <div
                v-if="hasTwoLevels"
                class="icon arrowDown"
                :class="[isSubOptionsExpanded(option) ? '' : 'right', isOptionDisabled(option) ? 'isDisabled' : '']"
              ></div>
              <span class="ellipsisText">{{ option[optionTextField] }}</span>
            </div>
            <div class="subOptionsBox" v-if="hasTwoLevels && isSubOptionsExpanded(option)">
              <div
                v-for="subOption in option[subOptionField]"
                v-if="isSubOptionVisible(option, subOption)"
                :key="subOption[subOptionValueField]"
                class="subOptionContainer"
                :class="{ selected: checkIsSubOptionSelected(option, subOption) }"
                @click="selectSubOption(option, subOption)"
              >
                <span class="ellipsisText">{{ subOption[subOptionTextField] }}</span>
              </div>
            </div>
          </div>
        </scrollable-box>
      </div>
    </transition>
  </div>
</template>

<script>
import ClickOutside from 'vue-click-outside';
import ScrollableBox from './scrollableBox';

export default {
  name: 'coolDropdown',
  components: {
    ScrollableBox,
  },
  props: {
    options: Array,
    optionValueField: {
      type: String,
      default: '',
    },
    optionTextField: {
      type: String,
      default: '',
    },
    subOptionField: {
      type: String,
      default: '',
    },
    subOptionValueField: {
      type: String,
      default: '',
    },
    subOptionTextField: {
      type: String,
      default: '',
    },
    hasTwoLevels: {
      type: Boolean,
      default: false,
    },
    selectedOptionValue: {
      type: String,
      default: '',
    },
    selectedSubOptionValue: {
      type: String,
      default: '',
    },
  },
  data() {
    return {
      isExpanded: false,
      searchText: '',
      expandClicked: false,
      expandedOptionIds: [],
      selectedValueSet: {
        optionValue: '',
        subOptionValue: '',
      },
    };
  },
  computed: {
    requireSearch() {
      return this.searchText.length > 1;
    },
    hasSelectedValue() {
      return this.selectedValueSet.optionValue !== '' || this.selectedValueSet.subOptionValue !== '';
    },
    selectedText() {
      if (this.hasTwoLevels) {
        const selectedSubOptionValue = this.selectedValueSet.subOptionValue.toString();
        if (selectedSubOptionValue !== '') {
          for (let i = 0; i < this.options.length; i += 1) {
            const opt = this.options[i];
            for (let j = 0; j < opt[this.subOptionField].length; j += 1) {
              const subOpt = opt[this.subOptionField][j];
              if (selectedSubOptionValue === subOpt[this.subOptionValueField].toString()) {
                return subOpt[this.subOptionTextField];
              }
            }
          }
        }
      } else {
        const selectedOptionValue = this.selectedValueSet.optionValue.toString();
        if (selectedOptionValue !== '') {
          const found = this.options.find(o => o[this.optionValueField].toString() === selectedOptionValue);
          if (found) {
            return found[this.optionTextField];
          }
        }
      }

      return 'Please Select';
    },
  },
  directives: {
    ClickOutside,
  },
  methods: {
    toggleExpand() {
      this.expandClicked = true;
      this.isExpanded = !this.isExpanded;
    },
    clickOutsideDropdownContainer() {
      if (!this.expandClicked && this.isExpanded) {
        this.isExpanded = false;
      } else {
        this.expandClicked = false;
      }
    },
    onClickOption(opt) {
      if (this.hasTwoLevels) {
        this.toggleSubOptions(opt);
      } else {
        this.selectedValueSet = {
          optionValue: opt[this.optionValueField].toString(),
          subOptionValue: '',
        };

        this.$emit('select', opt[this.optionValueField].toString());
        this.isExpanded = false;
      }
    },
    toggleSubOptions(opt) {
      if (!this.isOptionDisabled(opt)) {
        if (!this.isSubOptionsExpanded(opt)) {
          this.expandedOptionIds.push(opt[this.optionValueField]);
        } else {
          const myIndex = this.expandedOptionIds.findIndex(id => id === opt[this.optionValueField]);
          this.expandedOptionIds.splice(myIndex, 1);
        }
      }
    },
    checkNotNullEmptyString(obj) {
      return typeof obj !== 'undefined' && obj !== null && obj !== '' && obj.toString() !== '';
    },
    checkNotNullEmptyArray(obj) {
      return typeof obj !== 'undefined' && obj !== null && Array.isArray(obj);
    },
    isOptionVisible(opt) {
      const isOptionMatchedSearch =
        this.checkNotNullEmptyString(this.optionTextField) &&
        this.checkNotNullEmptyString(opt[this.optionTextField]) &&
        opt[this.optionTextField]
          .toString()
          .toLowerCase()
          .indexOf(this.searchText) > -1;

      const isSubOptionMatchedSearch =
        this.hasTwoLevels &&
        this.checkNotNullEmptyString(this.subOptionField) &&
        this.checkNotNullEmptyArray(opt[this.subOptionField]) &&
        opt[this.subOptionField].some(
          so =>
            so[this.subOptionTextField]
              .toString()
              .toLowerCase()
              .indexOf(this.searchText) > -1,
        );

      const isVisible = !this.requireSearch || isOptionMatchedSearch || isSubOptionMatchedSearch;
      return isVisible;
    },
    isSubOptionVisible(opt, subOpt) {
      const isOptionMatchedSearch =
        this.checkNotNullEmptyString(this.optionTextField) &&
        this.checkNotNullEmptyString(opt[this.optionTextField]) &&
        opt[this.optionTextField]
          .toString()
          .toLowerCase()
          .indexOf(this.searchText) > -1;

      const isSubOptionMatchedSearch =
        this.hasTwoLevels &&
        this.checkNotNullEmptyString(this.subOptionField) &&
        this.checkNotNullEmptyArray(opt[this.subOptionField]) &&
        subOpt[this.subOptionTextField]
          .toString()
          .toLowerCase()
          .indexOf(this.searchText) > -1;

      const isVisible = !this.requireSearch || isOptionMatchedSearch || isSubOptionMatchedSearch;
      return isVisible;
    },
    doSearch() {},
    clearSearch() {
      this.searchText = '';
      this.doSearch();
    },
    isOptionDisabled(opt) {
      const hasSubOptions =
        this.checkNotNullEmptyString(this.subOptionField) &&
        this.checkNotNullEmptyArray(opt[this.subOptionField]) &&
        opt[this.subOptionField].length > 0;

      return this.hasTwoLevels && !hasSubOptions;
    },
    isSubOptionsExpanded(opt) {
      const isExpanded =
        opt &&
        this.checkNotNullEmptyString(this.optionValueField) &&
        this.checkNotNullEmptyString(opt[this.optionValueField]) &&
        this.expandedOptionIds.some(id => id === opt[this.optionValueField]);

      return isExpanded;
    },
    cleanSelectedValueSet() {
      this.selectedValueSet = {
        optionValue: '',
        subOptionValue: '',
      };
    },
    checkIsOptionSelected(opt) {
      const isSelected =
        !this.hasTwoLevels && this.selectedValueSet.optionValue.toString() === opt[this.optionValueField].toString();

      return isSelected;
    },
    checkIsSubOptionSelected(opt, subOpt) {
      const isSelected =
        this.selectedValueSet.optionValue.toString() === opt[this.optionValueField].toString() &&
        this.selectedValueSet.subOptionValue.toString() === subOpt[this.subOptionValueField].toString();

      return isSelected;
    },
    selectSubOption(opt, subOpt) {
      this.selectedValueSet = {
        optionValue: opt[this.optionValueField].toString(),
        subOptionValue: subOpt[this.subOptionValueField].toString(),
      };

      this.$emit('select', opt[this.optionValueField].toString(), subOpt[this.subOptionValueField].toString());
      this.isExpanded = false;
    },
  },
  mounted() {
    this.selectedValueSet = {
      optionValue: this.selectedOptionValue.toString(),
      subOptionValue: this.selectedSubOptionValue.toString(),
    };
  },
};
</script>

<style lang="less" scoped>
.coolDropdownContainer {
  position: relative;
  .arrowDown {
    background: url('../../assets/images/arrow_down.png') no-repeat center;
    background-size: 100% 100%;
    width: 24px;
    height: 24px;
    transition: 0.3s all ease-in-out;
    &.up {
      transform: rotate(180deg);
    }
    &.left {
      transform: rotate(90deg);
    }
    &.right {
      transform: rotate(-90deg);
    }
    &.isDisabled {
      pointer-events: none;
      opacity: 0.5;
    }
  }
  .ellipsisText {
    display: inline-block;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  }
  .selectedResult {
    border: 1px solid #979797;
    border-radius: 2px;
    box-sizing: border-box;
    width: 100%;
    height: 32px;
    justify-content: space-between;
    box-sizing: border-box;
    align-items: center;
    display: flex;
    cursor: pointer;
    .text {
      display: flex;
      align-items: center;
      width: 100%;
      box-sizing: border-box;
      padding-left: 5px;
      overflow: hidden;
      &.tip {
        color: #888888;
      }
    }
    .text + .arrowDown {
      flex-shrink: 0;
      flex-grow: 0;
    }
  }
  .fade-enter-active,
  .fade-leave-active {
    transition: opacity 0.5s;
  }
  .fade-enter,
  .fade-leave-to {
    opacity: 0;
  }
  .dropdownListContainer {
    position: absolute;
    top: 32px;
    width: 100%;
    padding: 5px;
    box-sizing: border-box;
    z-index: 1;
    background-color: #ffffff;
    border-radius: 2px;
    box-shadow: 0 1px 8px 0 rgba(60, 73, 112, 0.25);
    transition: 0.3s all ease-in-out;
    .searchContainer {
      border: 1px solid black;
      border-radius: 2px;
      width: 100%;
      height: 30px;
      display: flex;
      justify-content: space-between;
      align-items: center;
      .valueContainer {
        flex-grow: 1;
        display: flex;
        align-items: center;
        height: 100%;
        .value {
          flex-grow: 1;
          width: 100%;
          height: 100%;
          border: none;
          outline: none;
          box-sizing: border-box;
          font-size: 16px;
          font-family: Oswald-Regular;
          &:focus {
            outline: none !important;
          }
        }
        .cleanIcon {
          background: url('../../assets/images/clean.png') no-repeat center;
          background-size: 100% 100%;
          width: 16px;
          height: 16px;
          margin-left: 5px;
          flex-grow: 0;
          cursor: pointer;
        }
      }
      .searchIcon {
        background: url('../../assets/images/search.png') no-repeat center;
        background-size: 100% 100%;
        width: 20px;
        height: 20px;
        margin-left: 15px;
        cursor: pointer;
      }
    }
    .dropdownItemsContainer {
      display: flex;
      flex-direction: column;
      margin-top: 5px;
      color: #555555;
      max-height: 200px;
      .dropdownItem {
        display: flex;
        flex-direction: column;
        .optionContainer {
          display: flex;
          height: 30px;
          align-items: center;
          .icon {
            cursor: pointer;
            flex-shrink: 0;
          }
          &:hover {
            background: #cccccc;
          }
          &.selected {
            background-color: #dddddd;
          }
        }
        .subOptionsBox {
          display: flex;
          flex-direction: column;
          padding-left: 30px;
          .subOptionContainer {
            display: flex;
            align-items: center;
            &:hover {
              background: #cccccc;
            }
            &.selected {
              background-color: #dddddd;
            }
          }
        }
      }
    }
  }
}
</style>

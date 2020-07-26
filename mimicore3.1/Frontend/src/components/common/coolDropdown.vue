<template>
  <div class="coolDropdownContainer">
    <div class="selectedResult" @click="toggleExpand()">
      <div class="text" :class="{ tip: !hasSelectedValue }">{{ selectedText }}</div>
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
            v-if="
              !requireSearch ||
                option[optionTextField]
                  .toString()
                  .toLowerCase()
                  .indexOf(searchText) > -1 ||
                option[subOptionField].some(
                  so =>
                    so[subOptionTextField]
                      .toString()
                      .toLowerCase()
                      .indexOf(searchText) > -1,
                )
            "
          >
            <div
              class="optionContainer"
              @click="toggleSubOptions(option)"
              :class="isOptionExpandable(option) ? '' : 'isDisabled'"
            >
              <div
                class="icon arrowDown"
                :class="[isSubOptionsExpanded(option) ? '' : 'right', isOptionExpandable(option) ? '' : 'isDisabled']"
              ></div>
              <span class="ellipsisText">{{ option[optionTextField] }}</span>
            </div>
            <div class="subOptionsBox" v-if="isSubOptionsExpanded(option)">
              <div
                v-for="subOption in option[subOptionField]"
                v-if="
                  !requireSearch ||
                    option[optionTextField]
                      .toString()
                      .toLowerCase()
                      .indexOf(searchText) > -1 ||
                    subOption[subOptionTextField]
                      .toString()
                      .toLowerCase()
                      .indexOf(searchText) > -1
                "
                :key="subOption[subOptionValueField]"
                class="subOptionContainer"
                :class="{ selected: checkIsSubOptionSelected(subOption, option) }"
                @click="selectItem(subOption, option)"
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
    optionValueField: String,
    optionTextField: String,
    subOptionField: String,
    subOptionValueField: String,
    subOptionTextField: String,
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
      const selectedValue = this.selectedValueSet.subOptionValue.toString();
      if (selectedValue !== '') {
        for (let i = 0; i < this.options.length; i += 1) {
          const opt = this.options[i];
          for (let j = 0; j < opt[this.subOptionField].length; j += 1) {
            const subOpt = opt[this.subOptionField][j];
            if (selectedValue === subOpt[this.subOptionValueField].toString()) {
              return subOpt[this.subOptionTextField];
            }
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
    toggleSubOptions(opt) {
      if (this.isOptionExpandable(opt)) {
        if (!this.isSubOptionsExpanded(opt)) {
          this.expandedOptionIds.push(opt[this.optionValueField]);
        } else {
          const myIndex = this.expandedOptionIds.findIndex(id => id === opt[this.optionValueField]);
          this.expandedOptionIds.splice(myIndex, 1);
        }
      }
    },
    doSearch() {},
    clearSearch() {
      this.searchText = '';
      this.doSearch();
    },
    isOptionExpandable(opt) {
      const hasSubOptions =
        this.subOptionField !== null &&
        this.subOptionField !== '' &&
        Array.isArray(opt[this.subOptionField]) &&
        opt[this.subOptionField].length > 0;

      return hasSubOptions;
    },
    isSubOptionsExpanded(opt) {
      const isExpanded =
        opt &&
        typeof this.optionValueField !== 'undefined' &&
        this.optionValueField !== '' &&
        typeof opt[this.optionValueField] !== 'undefined' &&
        this.expandedOptionIds.some(id => id === opt[this.optionValueField]);

      return isExpanded;
    },
    cleanSelectedValueSet() {
      this.selectedValueSet = {
        optionValue: '',
        subOptionValue: '',
      };
    },
    checkIsSubOptionSelected(subOpt, opt) {
      const isSelected =
        this.selectedValueSet.optionValue.toString() === opt[this.optionValueField].toString() &&
        this.selectedValueSet.subOptionValue.toString() === subOpt[this.subOptionValueField].toString();

      return isSelected;
    },
    selectItem(subOpt, opt) {
      this.selectedValueSet = {
        optionValue: opt[this.optionValueField],
        subOptionValue: subOpt[this.subOptionValueField],
      };

      this.$emit('select', subOpt[this.subOptionValueField].toString(), opt[this.optionValueField].toString());
      this.isExpanded = false;
    },
  },
  mounted() {
    this.selectedValueSet = {
      optionValue: this.selectedOptionValue,
      subOptionValue: this.selectedSubOptionValue,
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
    padding: 0 5px;
    .text {
      &.tip {
        color: #888888;
      }
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
          .ellipsisText {
            display: inline-block;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
          }
          &:hover {
            background: #cccccc;
          }
        }
        .subOptionsBox {
          display: flex;
          flex-direction: column;
          padding-left: 30px;
          .subOptionContainer {
            display: flex;
            align-items: center;
            .ellipsisText {
              display: inline-block;
              overflow: hidden;
              white-space: nowrap;
              text-overflow: ellipsis;
            }
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

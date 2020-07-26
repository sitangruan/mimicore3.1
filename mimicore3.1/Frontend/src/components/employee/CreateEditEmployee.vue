<template>
  <div class="createModal">
    <div class="functionRow">
      <div class="buttonContainer" @click="navigateToGridPage()">
        <div class="icon"></div>
        <div>Back to Employees</div>
      </div>
    </div>
    <div class="content">
      <input type="button" @click="clickMe" value="testme" />
      <br /><br />
      <cool-input :inputValue.sync="firstName" class="normalText" inputName="First Name"></cool-input>
      <br />
      <cool-input :inputValue.sync="lastName" class="normalText" inputName="Last Name"></cool-input>
      <br />
      <cool-dropdown
        class="cityDropdown"
        :options="provinceCities"
        optionValueField="id"
        optionTextField="name"
        subOptionField="cities"
        subOptionValueField="id"
        subOptionTextField="name"
        :selectedSubOptionValue="cityId"
        @select="onSelectCity"
      ></cool-dropdown>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import CoolInput from '../common/coolInput';
import CoolDropdown from '../common/coolDropdown';

export default {
  name: 'CreateEditEmployee',
  data() {
    return {
      firstName: '',
      lastName: '',
      cityId: '',
      provinceId: '',
    };
  },
  computed: {
    ...mapGetters('common', ['provinceCities']),
  },
  components: {
    CoolInput,
    CoolDropdown,
  },
  methods: {
    ...mapActions('employee', ['navigateToGridPage']),
    ...mapActions('common', ['loadProvinceCities']),
    onSelectCity(cityId, provinceId) {
      this.cityId = cityId;
      this.provinceId = provinceId;
    },
    clickMe() {
      console.log('First Name');
      console.log(this.firstName);
      console.log('City Id');
      console.log(this.cityId);
    },
  },
  created() {
    this.loadProvinceCities();
  },
};
</script>

<style lang="less" scoped>
.createModal {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  .functionRow {
    display: flex;
    align-items: center;
    height: 48px;
    .buttonContainer {
      display: flex;
      align-items: center;
      height: 28px;
      cursor: pointer;
      .icon {
        background: url('../../assets/images/backArrow.png') no-repeat center;
        background-size: 100% 100%;
        width: 24px;
        height: 24px;
        margin-right: 10px;
      }
    }
  }
  .content {
    .normalText {
      width: 360pz;
    }
    .cityDropdown {
      width: 360px;
    }
  }
}
</style>

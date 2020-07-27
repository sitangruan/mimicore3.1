<template>
  <div class="createModal">
    <div class="functionRow">
      <div class="buttonContainer" @click="navigateToGridPage()">
        <div class="icon"></div>
        <div>Back to Employees</div>
      </div>
    </div>
    <div class="content">
      <input type="button" @click="clickMe" value="Test Me" />
      <br /><br />
      <cool-input :inputValue.sync="firstName" class="firstNameInput" inputName="First Name"></cool-input>
      <br />
      <cool-input :inputValue.sync="lastName" class="lastNameInput" inputName="Last Name"></cool-input>
      <br />
      <cool-dropdown
        class="cityDropdown"
        :options="provinceCities"
        optionValueField="id"
        optionTextField="name"
        subOptionField="cities"
        subOptionValueField="id"
        subOptionTextField="name"
        :hasTwoLevels="true"
        :selectedSubOptionValue="cityId"
        @select="onSelectCity"
      ></cool-dropdown>
      <br />
      <cool-dropdown
        class="provinceDropdown"
        :options="provinceCities"
        optionValueField="id"
        optionTextField="name"
        :selectedOptionValue="singleLevelProvinceId"
        @select="onSelectProvince"
      ></cool-dropdown>
      <br />
      <cool-dropdown
        class="cityDropdown"
        :options="provinceCities"
        optionValueField="id"
        optionTextField="name"
        subOptionField="cities"
        subOptionValueField="id"
        subOptionTextField="name"
        :hasTwoLevels="true"
        :disabled="true"
        selectedSubOptionValue="7"
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
      singleLevelProvinceId: '',
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
    onSelectCity(provinceId, cityId) {
      this.provinceId = provinceId;
      this.cityId = cityId;
    },
    onSelectProvince(provinceId) {
      this.singleLevelProvinceId = provinceId;
    },
    clickMe() {
      console.log('First Name');
      console.log(this.firstName);
      console.log('Last Name');
      console.log(this.lastName);
      console.log('City Id');
      console.log(this.cityId);
      console.log('provinceId Id');
      console.log(this.provinceId);
      console.log('singleLevelProvinceId Id');
      console.log(this.singleLevelProvinceId);
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
    input[type='button'] {
      font-family: Oswald-Regular;
      font-size: 16px;
    }
    .firstNameInput {
      width: 300px;
    }
    .lastNameInput {
      width: 400px;
    }
    .cityDropdown {
      width: 300px;
    }
    .provinceDropdown {
      width: 400px;
    }
  }
}
</style>

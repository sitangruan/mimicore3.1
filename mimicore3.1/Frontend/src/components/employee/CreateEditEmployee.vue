<template>
  <div class="createModal">
    <div class="functionRow">
      <div class="buttonContainer" @click="navigateToGridPage()">
        <div class="icon"></div>
        <div>{{ isEditMode ? 'Edit Employee' : 'Create New Employee' }}</div>
      </div>
    </div>
    <div class="content">
      <div class="inputRow nameRow">
        <cool-input :inputValue.sync="firstName" class="nameInput" inputName="First Name"></cool-input>
        <cool-input :inputValue.sync="lastName" class="nameInput" inputName="Last Name"></cool-input>
      </div>
      <div class="inputRow addressRow">
        <cool-input :inputValue.sync="address" class="addressInput" inputName="Address"></cool-input>
      </div>
      <div class="dropdownRow">
        <div class="dropdownCell">
          <div class="label">City</div>
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
        </div>
        <div class="dropdownCell">
          <div class="label">Department</div>
          <cool-dropdown
            class="departmentDropdown"
            :options="departments"
            optionValueField="id"
            optionTextField="name"
            :selectedOptionValue="departmentId"
            @select="onSelectDepartment"
          ></cool-dropdown>
        </div>
      </div>
      <div class="buttonRow">
        <div class="buttonsContainer">
          <input type="button" @click="Save" value="Save" />
          <input type="button" @click="Cancel" value="Cancel" />
        </div>
      </div>
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
      address: '',
      cityId: '',
      provinceId: '',
      departmentId: '',
    };
  },
  computed: {
    ...mapGetters('common', ['provinceCities', 'departments']),
    ...mapGetters('employee', ['currentEmployeeId', 'currentEmployee', 'isEditMode']),
  },
  components: {
    CoolInput,
    CoolDropdown,
  },
  methods: {
    ...mapActions('employee', ['navigateToGridPage', 'createUpdateEmployee']),
    ...mapActions('common', ['loadProvinceCities', 'loadDepartments']),
    onSelectCity(provinceId, cityId) {
      this.provinceId = provinceId;
      this.cityId = cityId;
    },
    onSelectDepartment(departmentId) {
      this.departmentId = departmentId;
    },
    Save() {
      const emp = {
        FirstName: this.firstName,
        LastName: this.lastName,
        Address: this.address,
        CityId: this.cityId,
        DepartmentId: this.departmentId,
      };

      this.createUpdateEmployee(emp);
    },
    Cancel() {
      this.navigateToGridPage();
    },
  },
  created() {
    this.loadProvinceCities();
    this.loadDepartments();
    this.firstName = this.currentEmployee.firstName;
    this.lastName = this.currentEmployee.lastName;
    this.address = this.currentEmployee.address;
    this.cityId = this.currentEmployee.cityId.toString();
    this.departmentId = this.currentEmployee.departmentId.toString();
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
    display: flex;
    flex-direction: column;
    width: 610px;
    .inputRow {
      display: flex;
      align-items: center;
      margin-bottom: 10px;
      width: 100%;
      &.nameRow {
        justify-content: space-between;
        .nameInput {
          width: 300px;
        }
      }
      &.addressRow {
        .addressInput {
          width: 100%;
        }
      }
    }
    .dropdownRow {
      display: flex;
      align-items: center;
      margin-bottom: 30px;
      justify-content: space-between;
      width: 100%;
      .dropdownCell {
        display: flex;
        flex-direction: column;
        width: 300px;
        .label {
          line-height: 20px;
          margin-bottom: 5px;
        }
        .cityDropdown {
        }
        .departmentDropdown {
        }
      }
    }
    .buttonRow {
      width: 100%;
      display: flex;
      justify-content: center;
      align-items: center;
      .buttonsContainer {
        input[type='button'] {
          width: 80px;
        }
        input[type='button']:first-child {
          margin-right: 40px;
        }
      }
    }
  }
}
</style>

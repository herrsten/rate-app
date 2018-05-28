import skillsTemplate from "./skills.html";
import "./skills.scss";
import { getSkills, addSkill } from "../../services/apiService";

export const SkillsCtrl = function ($scope, toaster) {
    this.$onInit = () => {
        getSkills().then(skills => {
            this.skills = skills;
            $scope.$apply();
        }, error => {
            toaster.pop("error", error);
            $scope.$apply();
        });
    };

    this.removeSkill = skill => {
        const index = this.skills.indexOf(this.skills.find(s => s.id === skill.id));
        if (index !== -1) {
            this.skills.splice(index, 1);
            $scope.$apply();
        };
    }

    this.addSkill = skill => {
        addSkill(skill).then(skill => {
            this.skills.push(skill);
            $scope.$apply();
        }, error => {
            toaster.pop("error", error);
            $scope.$apply();
        });
    };
};

SkillsCtrl.$inject = ["$scope", "toaster"];

export default {
    controller: SkillsCtrl,
    template: skillsTemplate,
    bindings: {

    }
}
import skillTemplate from "./skill.html";
import "./skill.scss";
import { scoreOptions } from "../../constants";
import { deleteSkill, updateSkill } from "../../services/apiService";

export const SkillCtrl = function (toaster, $scope) {
    this.$onInit = () => {
        this.scores = scoreOptions;
        this.selectedScore = this.skill.score;
    };

    this.setScore = score => {
        const skillDto = {
            name: this.skill.name,
            score: score,
            id: this.skill.id
        };
        
        updateSkill(skillDto).then(success => {
            this.selectedScore = score;
            this.skill.score = score;
            $scope.$apply();
        }, error => {
            toaster.pop("error", error);
            $scope.$apply();
        });
    };

    this.remove = () => {
        deleteSkill(this.skill.id).then(success => {
            this.onSkillRemoved({ skill: this.skill });
        }, error => {
            toaster.pop("error", error);
            $scope.$apply();
        });
    };
};

SkillCtrl.$inject = ["toaster", "$scope"];

export default {
    controller: SkillCtrl,
    template: skillTemplate,
    bindings: {
        skill: "<",
        onSkillRemoved: "&",
        onScoreUpdated: "&",
    }
}
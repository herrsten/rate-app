import skillInputTemplate from "./skillInput.html";
import "./skillInput.scss";
import { scoreOptions } from "../../constants";

export const SkillInputCtrl = function () {
    const createSkillModel = () => {
        this.skillModel = {
        name: null,
        score: null
        }
    };
    
    this.$onInit = () => {
        this.scores = scoreOptions;
        createSkillModel();
    };

    this.validate = () => {
        if (this.skillModel.score === null || !this.skillModel.name) {
            this.isValid = false;
        }
        else {
            this.isValid = true;
        }
    };

    this.setScore = score => {
        this.skillModel.score = score;
        this.selectedScore = score;
        this.validate();
    };

    this.addSkill = () => {
        this.onSave({ skill: this.skillModel });
        createSkillModel();
        this.selectedScore = null;
        this.validate();
    };
};

SkillInputCtrl.$inject = [];

export default {
    controller: SkillInputCtrl,
    template: skillInputTemplate,
    bindings: {
        onSave: "&"
    }
}
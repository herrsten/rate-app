import scoreTemplate from "./score.html";

export const ScoreCtrl = function() {
    this.select = () => {
        this.isSelected = true;
        this.onScoreSelected({selectedScore: this.score});
    };
};

ScoreCtrl.$inject = [];

export default {
    controller: ScoreCtrl,
    template: scoreTemplate,
    bindings: {
        score: "<",
        onScoreSelected: "&",
        isSelected: "<"
    }
}
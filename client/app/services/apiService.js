import httpService from "./httpService";

export const getSkills = () => {
    return httpService(
        "http://localhost:5300",
        "api/ratings"
    ).then(res => {
        return res.json();
    });
};

export const getSkill = skillId => {
    return httpService(
        "http://localhost:5300",
        `api/ratings/${skillId}`
    ).then(res => {
        return res.json();
    });
};


export const addSkill = skill => {
    return httpService(
        "http://localhost:5300",
        "api/ratings",
        {
            method: "POST",
            body: JSON.stringify(skill),
        },
        { "Content-Type": "application/json" },
    ).then(res => {
        if (res.status >= 400) {
            return new Promise((resolve, reject) => {
                res.text()
                    .then(reject);
            });
        }
        return res.json();
    });
};

export const updateSkill = skill => {
    return httpService(
        "http://localhost:5300",
        `api/ratings/${skill.id}`,
        {
            method: "PUT",
            body: JSON.stringify({ name: skill.name, score: skill.score }),
        },
        { "Content-Type": "application/json" }
    ).then(res => {
        if (res.status >= 400) {
            return new Promise((resolve, reject) => {
                res.text().then(rejetct);
            })
        }
        else if (res.status === 201) {
            return res.json();
        }
        else {
            return res;
        }
    });
};

export const deleteSkill = skillId => {
    return httpService(
        "http://localhost:5300",
        `api/ratings/${skillId}`,
        {
            method: "DELETE"
        }
    ).then(res => {
        if (res.status >= 400) {
            return new Promise((resolve, reject) => {
                res.text()
                    .then(reject);
            });
        }
        return res;
    });
};
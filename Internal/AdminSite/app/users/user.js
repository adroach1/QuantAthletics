"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const http_1 = require("@angular/http");
class User {
}
exports.User = User;
class UserSearch {
    getSearchParams() {
        var params = new http_1.URLSearchParams();
        if (this.Id != null)
            params.append("Id", this.Id.toString());
        if (this.Username != null)
            params.append("Username", this.Username);
        if (this.EmailAddress != null)
            params.append("EmailAddress", this.EmailAddress);
        return params;
    }
}
exports.UserSearch = UserSearch;
//# sourceMappingURL=user.js.map
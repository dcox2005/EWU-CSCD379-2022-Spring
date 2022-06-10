
import { NuxtAxiosInstance } from '@nuxtjs/axios'
class WordleToken {

    Random: string = "";
    UserId: string= "";
    UserName: string= "";
    BirthDate: string= "";
    aud: string= "";
    exp: number = 0
    "http://schemas.microsoft.com/ws/2008/06/identity/claims/role":string[] = []
    iss: string= "";
    jti: string= "";
    sub: string= "";
    get roles(): string[] {
        return this["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
    }

}
export class JWT {
    private static tokenInstance: string;
    private static _tokenData: WordleToken;
    private static _age: number

    public static setToken(token:string, axios: NuxtAxiosInstance) {
        this.tokenInstance = token;
        axios.setHeader('Authorization', `Bearer ${token}`);
        const parts = token.split('.');
        const payload = JSON.parse(atob(parts[1]));
        this._tokenData = Object.assign(new WordleToken, payload);
        const [month, day, year] = this._tokenData.BirthDate.split('/');
        this._age = this.setAge(new Date(+year, +month - 1, +day));
    }

    public static getToken(): string {
        return this.tokenInstance;
    }

    public static get tokenData(): WordleToken {
        return this._tokenData;
    }

    public static reset()
    {
        this._tokenData.Random = "";
        this._tokenData.UserId = "";
        this._tokenData.UserName = "";
        this._tokenData.BirthDate = "";
        this._tokenData.aud = "";
        this._tokenData.exp = 0;
        this._tokenData.iss = "";
        this._tokenData.jti = "";
        this._tokenData.sub = "";
        this._tokenData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] = [];
        this.tokenInstance = "";
    }

    public static get age(): number{
        return this._age;
    }

    private static setAge(DOB: Date) {
        var today = new Date();
        var birthDate = DOB;
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }    
        return age;
    }
}

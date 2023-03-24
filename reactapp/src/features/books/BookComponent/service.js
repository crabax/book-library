
class bookService  {

    #toFormData(obj) {
        let urlParams = [];
        for (let key in (obj || {})) {
            urlParams.push(`${key}=${obj[key]?.toString() || ''}`);
        }

        let formData = urlParams.join("&")
        if(formData) formData = `?${formData}`
        return formData;
    }

    getList = async(payload) => {
        let urlParams = this.#toFormData(payload);
        const response = await fetch('api/Books' + urlParams);
        const data = await response.json();
        return data;
    }

};

export default bookService = new bookService();
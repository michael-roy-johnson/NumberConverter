﻿import Axios from 'axios';

export default class NumberConverter {
    static GetNumberToWords(number) {
        return Axios.get('http://localhost:5000/api/converter/' + number)
            .then(res => {
                return res;
            });
    }
}
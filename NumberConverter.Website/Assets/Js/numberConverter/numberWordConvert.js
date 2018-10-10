import React from 'react';
import ReactDOM from 'react-dom';
import NumberInput from './numberInput';
import WordOutput from './wordOutput';
import NumberConvertApi from '../api/numberConverter';

class NumberWordConvert extends React.Component {
    constructor(props) {
        super(props);
        this.state = { words: '' };

        this.handleNumber = this.handleNumber.bind(this);

    }

    handleNumber(number) {
        NumberConvertApi.GetNumberToWords(number)
            .then(res => {
                this.setState({ words: res.data });
            });
    }

    render() {
        return (
            <div className="number-converter">
                <h1 className="number-converter__title">Number Converter</h1>
                <NumberInput onSetNumber={this.handleNumber} />
                <WordOutput {...this.state} />
            </div>
        )
    }
}

ReactDOM.render(
    <NumberWordConvert />,
    document.getElementById('number-converter')
);

export default NumberWordConvert;
import React from 'react';
import ReactDOM from 'react-dom';
import UserDetailsInput from './userDetailsInput';
import WordOutput from './wordOutput';
import NumberConvertApi from '../api/numberConverter';

class NumberWordConvert extends React.Component {
    constructor(props) {
        super(props);
        this.state = { name: '', words: '' };

        this.handleUserDetails = this.handleUserDetails.bind(this);

    }

    handleUserDetails(props) {
        console.log(props);
        NumberConvertApi.GetNumberToWords(props.number)
            .then(res => {
                this.setState({ name: props.name });
                this.setState({ words: res.data });
            })
            .catch(err => {
                this.setState({ words: 'We could not process your request.' })
            });
    }

    render() {
        return (
            <div className="number-converter">
                <h1 className="number-converter__title">Number Converter</h1>
                <UserDetailsInput onSetUserDetails={this.handleUserDetails} />
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
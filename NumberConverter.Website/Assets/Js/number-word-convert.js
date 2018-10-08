import React from 'react';
import NumberInput from 'NumberInput';
import WordOutput from 'WordOutput';

class NumberWordConvert extends React.Component {
    render() {
        return (
            <div>
                <NumberInput />
                <WordOutput />
            </div>
        )
    }
}

export default NumberWordConvert;
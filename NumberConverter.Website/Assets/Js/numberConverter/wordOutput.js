import React from 'react';

class WordOutput extends React.Component {
    render() {
        return (
            <div className="number-converter__output">
                {this.props.words}
            </div>
        )
    }
}

export default WordOutput;
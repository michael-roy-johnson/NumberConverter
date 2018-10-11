import React from 'react';

class WordOutput extends React.Component {
    render() {
        return (
            <div className="number-converter__output-container">
                <div className="number-converter__output__field">
                    {this.props.name}
                </div>
                <div className="number-converter__output__field">
                    {this.props.words}
                </div>
            </div>
        )
    }
}

export default WordOutput;